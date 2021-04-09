namespace FizzBuzz.Implementation.Contracts
{
    public class BaseResponse
    {
        /// <summary>
        /// Gets or Sets the success of the operation
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the Failure Information (user friendly failure message) if success is false
        /// </summary>
        public string FailureInformation { get; set; } = string.Empty;
    }
}
