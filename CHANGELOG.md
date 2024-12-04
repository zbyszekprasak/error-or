# Changelog

All notable changes to this project are documented in this file.

## [2.1.0-alpha.0] - to be released

### Added

- [#94](https://github.com/amantinband/error-or/issues/94), [#95](https://github.com/amantinband/error-or/pull/95) Added missing async versions of `FailIf` methods

    ```cs
    public async Task<ErrorOr<TValue>> FailIfAsync(Func<TValue, Task<bool>> onValue, Error error)
    ```

    ```cs
    public static async Task<ErrorOr<TValue>> FailIf<TValue>(
        this Task<ErrorOr<TValue>> errorOr,
        Func<TValue, bool> onValue,
        Error error)
    ```

    ```cs
    public static async Task<ErrorOr<TValue>> FailIfAsync<TValue>(
        this Task<ErrorOr<TValue>> errorOr,
        Func<TValue, Task<bool>> onValue,
        Error error)
    ```

- [#104](https://github.com/amantinband/error-or/pull/104) Support for .NET 8 was added

- [#109](https://github.com/amantinband/error-or/issues/109), [#111](https://github.com/amantinband/error-or/pull/111) Added `FailIf` method overloads that allow to use value in error definition using `Func<TValue, Error>` error builder

    ```cs
    public ErrorOr<TValue> FailIf(Func<TValue, bool> onValue, Func<TValue, Error> errorBuilder)
    ```

    ```cs
    public async Task<ErrorOr<TValue>> FailIfAsync(Func<TValue, Task<bool>> onValue, Func<TValue, Task<Error>> errorBuilder)
    ```

    ```cs
    public static async Task<ErrorOr<TValue>> FailIf<TValue>(
        this Task<ErrorOr<TValue>> errorOr,
        Func<TValue, bool> onValue,
        Func<TValue, Error> errorBuilder)
    ```

    ```cs
    public static async Task<ErrorOr<TValue>> FailIfAsync<TValue>(
        this Task<ErrorOr<TValue>> errorOr,
        Func<TValue, Task<bool>> onValue,
        Func<TValue, Task<Error>> errorBuilder)
    ```

    Value can now be used to build the error:

    ```cs
    ErrorOr<int> result = errorOrInt
        .FailIf(num => num > 3, (num) => Error.Failure(description: $"{num} is greater than 3"));
    ```

### Optimized

- [#98](https://github.com/amantinband/error-or/issues/98), [#99](https://github.com/amantinband/error-or/pull/99) Memory consumption optimized by moving static empty errors lists from generic struct into non-generic class

## [2.0.1] - 2024-03-26

### Breaking Changes

- `Then` that receives an action is now called `ThenDo`

    ```diff
    -public ErrorOr<TValue> Then(Action<TValue> action)
    +public ErrorOr<TValue> ThenDo(Action<TValue> action)
    ```

    ```diff
    -public static async Task<ErrorOr<TValue>> Then<TValue>(this Task<ErrorOr<TValue>> errorOr, Action<TValue> action)
    +public static async Task<ErrorOr<TValue>> ThenDo<TValue>(this Task<ErrorOr<TValue>> errorOr, Action<TValue> action)
    ```

- `ThenAsync` that receives an action is now called `ThenDoAsync`

    ```diff
    -public async Task<ErrorOr<TValue>> ThenAsync(Func<TValue, Task> action)
    +public async Task<ErrorOr<TValue>> ThenDoAsync(Func<TValue, Task> action)
    ```

    ```diff
    -public static async Task<ErrorOr<TValue>> ThenAsync<TValue>(this Task<ErrorOr<TValue>> errorOr, Func<TValue, Task> action)
    +public static async Task<ErrorOr<TValue>> ThenDoAsync<TValue>(this Task<ErrorOr<TValue>> errorOr, Func<TValue, Task> action)
    ```

### Added

- `FailIf`

    ```csharp
    public ErrorOr<TValue> FailIf(Func<TValue, bool> onValue, Error error)
    ```

    ```csharp
    ErrorOr<int> errorOr = 1;
    errorOr.FailIf(x => x > 0, Error.Failure());
    ```

## [1.10.0] - 2024-02-14

### Added

- `ErrorType.Forbidden`
- README to NuGet package

## [1.9.0] - 2024-01-06

### Added

- `ToErrorOr`
