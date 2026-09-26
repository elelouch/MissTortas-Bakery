using MissTortas.Domain.Orders;
using MissTortas.Domain.Payments;
using MissTortas.Domain.Products;
using MissTortas.Services.Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Infrastructure.Context
{
    public static class ProductMappingExtensions
    {
        public static IQueryable<ProductDADto> ToProductDADto(this IQueryable<Product> query)
        {
            return query.Select(p => new ProductDADto
            {
                Id = p.ProductId,
                CategoryId = p.ProductCategoryId,
                Description = p.ProductDetail.Description,
                Name = p.Name,
                UnitId = p.Unit.Id,
                Quantity = p.Quantity,
                Enabled = p.Enabled
            });
        }
        public static IQueryable<SaleProductDADto> ToSaleProductDADto(this IQueryable<SaleProduct> query)
        {
            return query.Select(sp => new SaleProductDADto
            {
                Id = sp.SaleProductId,
                StockProductId = sp.ProductId,
                Name = sp.Product.Name,
                Description = sp.Product.ProductDetail.Description,
                SaleQuantity = sp.SaleQuantity,
                StockQuantity = sp.Product.Quantity,
                SalePrice = sp.SalePrice,
                UnitId = sp.Product.Unit.Id,
                Enabled = sp.Product.Enabled,
                IsAvailable = sp.IsAvailable,
                CategoryId = sp.Product.ProductCategoryId
            });
        }
        public static IQueryable<OrderPreparationDADto> ToOrderPreparationDADto(this IQueryable<OrderPreparation> query)
        {
            return query.Select(op => new OrderPreparationDADto
            {
                Id = op.OrderPreparationId,
                Detail = op.Detail,
                Done = op.Done,
                AssigneeId = op.AssigneeId ?? 0
            });
        }

        public static IQueryable<OrderDADto> ToDetailedOrderDADto(this IQueryable<Order> query)
        {
            return query.Select(o => new OrderDADto {
                ClientUserId = o.Consultancy.Client.UserId,
                OrderId = o.OrderId,
                OrderStatus = o.OrderStatus,
                ConsultancyId = o.ConsultancyId,
                ConsultancyTitle = o.Consultancy.Title,
                ConsultancyCreationTime = o.Consultancy.CreationTime,
                Creation = o.CreationTime,
                OrderManagerId = o.Consultancy.AssigneeId ?? 0,
                PreparationDADtos = o.Preparations.Select(op => new OrderPreparationDADto
                {
                    Id = op.OrderPreparationId,
                    Detail = op.Detail,
                    Done = op.Done,
                    AssigneeId = op.AssigneeId ?? 0
                }).ToList(),
                SaleProductAskedDADtos = o.ProductsAsked.Select(osp => new SaleProductAskedDADto
                {
                    Id = osp.SaleProduct.SaleProductId,
                    Name = osp.SaleProduct.Product.Name,
                    Description = osp.SaleProduct.Product.ProductDetail.Description,
                    QuantityAsked = osp.QuantityAsked,
                    SalePrice = osp.SaleProduct.SalePrice
                }).ToList(),
                PaymentStatus = o.PaymentRequest == null ? PaymentStatus.Pending : (o.PaymentRequest.Payment == null ? PaymentStatus.Pending : o.PaymentRequest.Payment.PaymentStatus)
            });
        }
        public static IQueryable<OrderDADto> ToOrderDADto(this IQueryable<Order> query)
        {
            return query.Select(o => new OrderDADto
            {
                ClientUserId = o.Consultancy.Client.UserId,
                OrderId = o.OrderId,
                OrderStatus = o.OrderStatus,
                ConsultancyId = o.ConsultancyId,
                ConsultancyTitle = o.Consultancy.Title,
                ConsultancyCreationTime = o.Consultancy.CreationTime,
                Creation = o.CreationTime,
                OrderManagerId = o.Consultancy.AssigneeId ?? 0,
                PaymentStatus = o.PaymentRequest == null ? PaymentStatus.Pending : (o.PaymentRequest.Payment == null ? PaymentStatus.Pending : o.PaymentRequest.Payment.PaymentStatus)
            });
        }
    }
}
