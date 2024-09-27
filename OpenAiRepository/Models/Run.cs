using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Repository.OpenAi.Models;

public class Run
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("created_at_date")]
    public DateTime CreatedAtDate
    {
        get
        {
            DateTime dateTime = DateTime.UnixEpoch;
            dateTime = dateTime.AddSeconds(CreatedAt).ToLocalTime();
            return dateTime;
        }
    }

    [JsonPropertyName("status")]
    public RunStatus Status { get; set; }

    [JsonPropertyName("expires_at")]
    public int? ExpiresAt { get; set; }

    [JsonPropertyName("expires_at_date")]
    public DateTime? ExpiresAtDate
    {
        get
        {
            if (ExpiresAt is null)
            {
                return null;
            }
            DateTime dateTime = DateTime.UnixEpoch;
            dateTime = dateTime.AddSeconds(ExpiresAt.Value).ToLocalTime();
            return dateTime;
        }
    }

    [JsonPropertyName("started_at")]
    public int? StartedAt { get; set; }

    [JsonPropertyName("started_at_date")]
    public DateTime? StartedAtDate
    {
        get
        {
            if (StartedAt is null)
            {
                return null;
            }
            DateTime dateTime = DateTime.UnixEpoch;
            dateTime = dateTime.AddSeconds(StartedAt.Value).ToLocalTime();
            return dateTime;
        }
    }

    [JsonPropertyName("cancelled_at")]
    public int? CancelledAt { get; set; }

    [JsonPropertyName("cancelled_at_date")]
    public DateTime? CancelledAtDate
    {
        get
        {
            if (CancelledAt is null)
            {
                return null;
            }
            DateTime dateTime = DateTime.UnixEpoch;
            dateTime = dateTime.AddSeconds(CancelledAt.Value).ToLocalTime();
            return dateTime;
        }
    }

    [JsonPropertyName("failed_at")]
    public int? FailedAt { get; set; }

    [JsonPropertyName("failed_at_date")]
    public DateTime? FailedAtDate
    {
        get
        {
            if (FailedAt is null)
            {
                return null;
            }
            DateTime dateTime = DateTime.UnixEpoch;
            dateTime = dateTime.AddSeconds(FailedAt.Value).ToLocalTime();
            return dateTime;
        }
    }

    [JsonPropertyName("completed_at")]
    public int? CompletedAt { get; set; }

    [JsonPropertyName("completed_at_date")]
    public DateTime? CompletedAtDate
    {
        get
        {
            if (CompletedAt is null)
            {
                return null;
            }
            DateTime dateTime = DateTime.UnixEpoch;
            dateTime = dateTime.AddSeconds(CompletedAt.Value).ToLocalTime();
            return dateTime;
        }
    }

    [JsonPropertyName("thread_id")]
    public string? ThreadId { get; set; }

    [JsonPropertyName("assistant_id")]
    public string? AssistantId { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RunStatus
{
    queued,
    in_progress,
    requires_action,
    cancelling,
    cancelled,
    failed,
    completed,
    incomplete,
    expired
}