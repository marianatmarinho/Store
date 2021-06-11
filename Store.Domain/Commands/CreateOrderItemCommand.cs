using System;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;

namespace Store.Domain.Commands
{
    public class CreateOrderItemCommand : Notifiable, ICommand
    {
        public CreateOrderItemCommand(){}

        public CreateOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Guid Product { get; private set; }
        public int Quantity { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                            .Requires()
                            .HasLen(Product.ToString(),32,"Product", "Produto inválido")
                            .IsGreaterThan(Quantity,0, "Quantity", "Quantidade inválida"));
        }
    }
}