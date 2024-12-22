namespace ErrorOr;

/// <summary>
/// Strongly-typed interface for <see cref="ErrorOr{TValue}"/> object.
/// </summary>
/// <typeparam name="TValue">The type of the underlying <see cref="ErrorOr{TValue}.Value"/>.</typeparam>
public interface IErrorOr<out TValue> : IErrorOr
{
    /// <summary>
    /// Gets strongly-typed the value.
    /// </summary>
    new TValue Value { get; }
}

/// <summary>
/// Weakly-typed interface for the <see cref="ErrorOr{TValue}"/> object.
/// </summary>
/// <remarks>
/// This interface is intended for use when the underlying type of the <see cref="ErrorOr{TValue}"/> object is unknown.
/// </remarks>
public interface IErrorOr
{
    /// <summary>
    /// Gets weakly-typed value.
    /// </summary>
    object? Value { get; }

    /// <summary>
    /// Gets the list of errors.
    /// </summary>
    List<Error>? Errors { get; }

    /// <summary>
    /// Gets a value indicating whether the state is error.
    /// </summary>
    bool IsError { get; }
}
