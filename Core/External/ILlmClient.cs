// 파일: Core/External/ILlmClient.cs
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.External
{
    public interface ILlmClient
    {
        Task<string> CompleteAsync(
            string systemPrompt,
            IEnumerable<LlmMessage> messages,
            double? temperature = null,
            CancellationToken ct = default);
    }
}
