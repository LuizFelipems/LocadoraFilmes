
using FluentValidation.Results;

namespace LocadoraFilmes.Application.Commons.Responses
{
    public class Response<TData>
    {
        public TData? Data { get; protected set; }
        public List<MessageResult>? MessageResults { get; protected set; }

        public bool IsValid { get; protected set; }

        public static Response<TData> Success(TData data, ValidationResult? validationResult = default)
        {
            return new Response<TData>
            {
                Data = data,
                IsValid = validationResult is null ? true : validationResult.IsValid,
                MessageResults = validationResult?.GetErrors()
            };
        }

        public static Response<TData> Fail(ValidationResult? validationResult = default)
        {
            return new Response<TData> { MessageResults = validationResult?.GetErrors() };
        }
    }

    public class MessageResult
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public MessageResult(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }

    public static class ValidationResultExtensions
    {
        public static List<MessageResult>? GetErrors(this ValidationResult result)
        {
            return result.Errors?.Select(error => new MessageResult(error.PropertyName, error.ErrorMessage)).ToList();
        }
    }
}
