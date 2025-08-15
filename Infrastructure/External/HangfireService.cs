using System;
using System.Linq.Expressions;
using Hangfire;

namespace Infrastructure.External
{
    /// <summary>
    /// Hangfire 래퍼 서비스: 백그라운드 작업/정기 작업 스케줄링
    /// </summary>
    public class HangfireService
    {
        private readonly IBackgroundJobClient _background;
        private readonly IRecurringJobManager _recurring;

        public HangfireService(IBackgroundJobClient background, IRecurringJobManager recurring)
        {
            _background = background;
            _recurring = recurring;
        }

        // 즉시 실행
        public string Enqueue(Expression<Action> method)
            => _background.Enqueue(method);

        public string Enqueue<T>(Expression<Action<T>> method)
            => _background.Enqueue(method);

        // 지연 실행
        public string Schedule(Expression<Action> method, TimeSpan delay)
            => _background.Schedule(method, delay);

        public string Schedule<T>(Expression<Action<T>> method, TimeSpan delay)
            => _background.Schedule(method, delay);

        // 정기 작업
        public void AddOrUpdate(string jobId, Expression<Action> method, string cron)
            => _recurring.AddOrUpdate(jobId, method, cron);

        public void AddOrUpdate<T>(string jobId, Expression<Action<T>> method, string cron)
            => _recurring.AddOrUpdate(jobId, method, cron);

        public void RemoveIfExists(string jobId)
            => _recurring.RemoveIfExists(jobId);
    }
}
