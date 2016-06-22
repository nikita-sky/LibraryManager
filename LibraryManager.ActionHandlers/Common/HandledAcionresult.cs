namespace LibraryManager.ActionHandlers.Common
{
    public class HandledActionResult
    {
        public HandledActionResultCode Code { get; }

        public HandledActionResult(HandledActionResultCode code)
        {
            Code = code;
        }

        public static readonly HandledActionResult Success = new HandledActionResult(HandledActionResultCode.Success);
        public static readonly HandledActionResult NotFound = new HandledActionResult(HandledActionResultCode.NotFound);
        public static readonly HandledActionResult BadRequest = new HandledActionResult(HandledActionResultCode.BadRequest);
        public static readonly HandledActionResult Failure = new HandledActionResult(HandledActionResultCode.Failure);
        public static readonly HandledActionResult Forbidden = new HandledActionResult(HandledActionResultCode.Forbidden);
    }

    public class HandledActionResult<TData> : HandledActionResult
    {
        public TData Data { get; set; }

        public HandledActionResult(HandledActionResultCode code) : base(code)
        {
        }

        public new static HandledActionResult<TData> Success(TData data)
            => new HandledActionResult<TData>(HandledActionResultCode.Success) { Data = data };

        public new static HandledActionResult<TData> NotFound = new HandledActionResult<TData>(HandledActionResultCode.NotFound);
        public new static readonly HandledActionResult<TData> BadRequest = new HandledActionResult<TData>(HandledActionResultCode.BadRequest);
        public new static readonly HandledActionResult<TData> Failure = new HandledActionResult<TData>(HandledActionResultCode.Failure);
        public new static readonly HandledActionResult<TData> Forbidden = new HandledActionResult<TData>(HandledActionResultCode.Forbidden);
    }
}