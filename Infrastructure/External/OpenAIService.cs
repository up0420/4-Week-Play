using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Core.External;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.External
{
    /// <summary>
    /// OpenAI Chat Completions 클라이언트
    /// </summary>
    public class OpenAIService : ILlmClient
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;
        private readonly string _model;
        private readonly double _defaultTemperature;

        public OpenAIService(HttpClient httpClient, IConfiguration configuration)
        {
            _http = httpClient;
            _apiKey = configuration["OpenAI:ApiKey"]
                ?? throw new ArgumentNullException("OpenAI:ApiKey is missing");

            _model = configuration["OpenAI:Model"] ?? "gpt-4o-mini";
            _defaultTemperature = double.TryParse(configuration["OpenAI:Temperature"], out var t) ? t : 0.7;

            // 기본 BaseAddress 없으면 지정
            _http.BaseAddress ??= new Uri("https://api.openai.com/v1/");
        }

        /// <summary>
        /// 고수준 LLM 호출 (시스템 프롬프트 + 대화 메시지들)
        /// </summary>
        public async Task<string> CompleteAsync(
            string systemPrompt,
            IEnumerable<LlmMessage> messages,
            double? temperature = null,
            CancellationToken ct = default)
        {
            var req = new ChatCompletionsRequest
            {
                Model = _model,
                Temperature = temperature ?? _defaultTemperature,
                Messages = BuildMessages(systemPrompt, messages)
            };

            using var httpReq = new HttpRequestMessage(HttpMethod.Post, "chat/completions")
            {
                Content = JsonContent.Create(req)
            };
            httpReq.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            using var resp = await _http.SendAsync(httpReq, ct);
            resp.EnsureSuccessStatusCode();

            var payload = await resp.Content.ReadFromJsonAsync<ChatCompletionsResponse>(cancellationToken: ct)
                          ?? throw new InvalidOperationException("Empty response from OpenAI");

            if (payload.Choices is { Count: > 0 } && payload.Choices[0].Message is not null)
                return payload.Choices[0].Message!.Content ?? string.Empty;

            return string.Empty;
        }

        /// <summary>
        /// 기존에 쓰던 단일 프롬프트용 편의 메서드 (원하시면 유지)
        /// </summary>
        public Task<string> GetCompletionAsync(string prompt)
        {
            var sys = "You are a helpful assistant.";
            var msgs = new[] { new LlmMessage("user", prompt) };
            return CompleteAsync(sys, msgs);
        }

        private static List<ChatMessage> BuildMessages(string systemPrompt, IEnumerable<LlmMessage> msgs)
        {
            var list = new List<ChatMessage>
            {
                new ChatMessage { Role = "system", Content = systemPrompt }
            };
            foreach (var m in msgs)
                list.Add(new ChatMessage { Role = m.Role, Content = m.Content });
            return list;
        }

        // ---- OpenAI REST DTOs ----
        private sealed class ChatCompletionsRequest
        {
            [JsonPropertyName("model")] public string Model { get; set; } = "";
            [JsonPropertyName("messages")] public List<ChatMessage> Messages { get; set; } = new();
            [JsonPropertyName("temperature")] public double Temperature { get; set; } = 0.7;
        }

        private sealed class ChatMessage
        {
            [JsonPropertyName("role")] public string Role { get; set; } = "";
            [JsonPropertyName("content")] public string Content { get; set; } = "";
        }

        private sealed class ChatCompletionsResponse
        {
            [JsonPropertyName("choices")] public List<Choice> Choices { get; set; } = new();
        }

        private sealed class Choice
        {
            [JsonPropertyName("message")] public ChatMessage? Message { get; set; }
        }
    }
}
