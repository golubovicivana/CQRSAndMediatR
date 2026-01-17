namespace CQRSAndMediatR;
public record UpdateOrderDto(
    string ProductName,
    int UserId,
    decimal TotalAmount
);
