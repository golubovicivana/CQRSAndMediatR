using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Commands;

public record CreateOrderCommand(string productName, int userId, decimal totalAmount) : IRequest<int>;

