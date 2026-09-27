using MissTortas.Services.Exceptions;

namespace MissTortas.View.ErrorHandling.Exceptions
{
    // Presentation project
    public static class BusinessExceptionStatusMap
    {
        private static readonly Dictionary<Type, (int StatusCode, string Title)> Map = new()
        {
            // --- 404 Not Found: lookups that failed ---
            [typeof(ConsultancyNotFoundException)] = (StatusCodes.Status404NotFound, "Consultancy not found"),
            [typeof(EntityNotFoundException)] = (StatusCodes.Status404NotFound, "Resource not found"),
            [typeof(OrderNotFoundException)] = (StatusCodes.Status404NotFound, "Order not found"),
            [typeof(OrderTypeNotFoundException)] = (StatusCodes.Status404NotFound, "Order type not found"),
            [typeof(PermissionNotFoundException)] = (StatusCodes.Status404NotFound, "Permission not found"),
            [typeof(ProductCategoryNotFoundException)] = (StatusCodes.Status404NotFound, "Product category not found"),
            [typeof(ProductNotFoundException)] = (StatusCodes.Status404NotFound, "Product not found"),
            [typeof(RoleNotFound)] = (StatusCodes.Status404NotFound, "Role not found"),
            [typeof(SaleProductNotFoundException)] = (StatusCodes.Status404NotFound, "Sale product not found"),
            [typeof(UserNotFoundException)] = (StatusCodes.Status404NotFound, "User not found"),

            // --- 409 Conflict: resource already exists, or valid request but current state forbids it ---
            [typeof(QuantityException)] = (StatusCodes.Status409Conflict, "Quantity is not correct."),
            [typeof(AlreadyCreatedException)] = (StatusCodes.Status409Conflict, "Resource already exists."),
            [typeof(ChildAppendException)] = (StatusCodes.Status409Conflict, "Cannot append child"),
            [typeof(InvalidOrderPreparationStateException)] = (StatusCodes.Status409Conflict, "Invalid order preparation state"),
            [typeof(InvalidOrderStateException)] = (StatusCodes.Status409Conflict, "Invalid order state"),
            [typeof(InvalidStateException)] = (StatusCodes.Status409Conflict, "Invalid state transition"),
            [typeof(ParentIsFinalException)] = (StatusCodes.Status409Conflict, "Parent is in a final state"),
            [typeof(SaleProductAlreadyAssociatedException)] = (StatusCodes.Status409Conflict, "Sale product already linked"),
            [typeof(UserAlreadyCreatedException)] = (StatusCodes.Status409Conflict, "User already exists"),

            // --- 400 Bad Request: invalid input/data supplied by the caller ---
            [typeof(AskQuantityException)] = (StatusCodes.Status400BadRequest, "Invalid quantity"),
            [typeof(PasswordException)] = (StatusCodes.Status400BadRequest, "Invalid password"),

            // --- 401 Unauthorized: identity/credentials/claims problems ---
            [typeof(InvalidClaimsException)] = (StatusCodes.Status401Unauthorized, "Invalid claims"),
            [typeof(AuthenticationFailedException)] = (StatusCodes.Status401Unauthorized, "Authentication failed"),

            // --- 402 Payment Required: closest semantic match for a failed payment ---
            [typeof(PaymentFailedException)] = (StatusCodes.Status402PaymentRequired, "Payment failed"),
        };

        public static (int StatusCode, string Title) Resolve(BusinessException ex) =>
            Map.TryGetValue(ex.GetType(), out var result)
                ? result
                : (StatusCodes.Status400BadRequest, "Business rule violation");
    }
}
