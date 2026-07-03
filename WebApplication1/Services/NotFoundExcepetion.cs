
namespace WebApplication1.Services {
    [Serializable]
    internal class NotFoundExcepetion : Exception {
        public NotFoundExcepetion() {
        }

        public NotFoundExcepetion(string? message) : base(message) {
        }

        public NotFoundExcepetion(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}