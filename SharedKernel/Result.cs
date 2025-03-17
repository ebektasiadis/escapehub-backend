using System.Diagnostics.CodeAnalysis;

namespace SharedKernel;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public Result(bool isSuccess, Error error)
    {
        if (IsSuccess == true && error != Error.None
            || IsSuccess == false && error != Error.None)
        {
            throw new ArgumentException("Result is not instantiated correctly");
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public Result(TValue? value, bool isSuccess, Error error): base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value => this.IsSuccess ? _value! : throw new InvalidOperationException("Result is not successful, thus you can not fetch it's value.");

    public static implicit operator Result<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.None);
}