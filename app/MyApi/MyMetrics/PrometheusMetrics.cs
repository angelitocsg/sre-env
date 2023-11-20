using Prometheus;

namespace MyApi.MyMetrics;

public static class PrometheusMetrics
{
    public static void UsePrometheusCustomMetrics(this WebApplication app)
    {
        app.UseMetricServer();
        app.UseHttpMetrics();
        app.UsePrometheusMiddleware();
    }

    private static void UsePrometheusMiddleware(this WebApplication app)
    {
        var counter = Metrics.CreateCounter("myapi_endpoint_requests", "Counts requests to the MyApi endpoints",
            new CounterConfiguration
            {
                LabelNames = new[] { "method", "endpoint" }
            });

        app.Use((context, next) =>
        {
            counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
            return next();
        });
    }
}
