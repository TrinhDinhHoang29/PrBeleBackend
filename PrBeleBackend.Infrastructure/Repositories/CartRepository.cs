using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly BeleStoreContext _context;
        public CartRepository(BeleStoreContext context)
        {
            _context = context;
        }
        public async Task<Cart> AddCart(Cart cart)
        {

            await _context.carts.AddAsync(cart);            
            await _context.SaveChangesAsync();
            return cart;

        }

        public async Task<bool> DeleteCart(int UserId)
        {
            Cart cart = await _context.carts.FirstAsync(a => a.UserId == UserId);
            _context.carts.Remove(cart);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Cart?> GetDetailCart(int UserId)
        {
            return await _context.carts
                .Include(a => a.ProductCarts)
                .ThenInclude(p => p.Variant)
                .ThenInclude(v => v.Product)
                .ThenInclude(p => p.Discount)
                .FirstOrDefaultAsync(c => c.UserId == UserId);
        }


        public async Task<Cart> UpdateCart(Cart cart)
        {
            // Tìm giỏ hàng tồn tại
            Cart? cartExist = await _context.carts
                .Include(c => c.ProductCarts)
                .ThenInclude(pc => pc.Variant)
                .ThenInclude(v => v.Product)
                .ThenInclude(p => p.Discount)
                .FirstOrDefaultAsync(a => a.UserId == cart.UserId);

            if (cartExist == null)
            {
                throw new Exception("Cart not found");
            }

            // Xử lý danh sách ProductCarts
            foreach (var productCart in cart.ProductCarts)
            {
                var existingProductCart = cartExist.ProductCarts
                    .FirstOrDefault(pc => pc.VariantId == productCart.VariantId);

                if (existingProductCart == null)
                {
                    cartExist.ProductCarts.Add(new ProductCart
                    {
                        CartId = cartExist.Id,
                        VariantId = productCart.VariantId,
                        Quantity = productCart.Quantity,
                    });
                }
                else
                {
                    existingProductCart.Quantity += productCart.Quantity;

                    if (existingProductCart.Quantity <= 0)
                    {
                        cartExist.ProductCarts.Remove(existingProductCart);
                    }
                }
            }

            // Cập nhật TotalMoney
            cartExist.TotalMoney = cartExist.ProductCarts
                .Sum(pc => pc.Variant.Price *
                    (pc.Variant.Product.Discount != null && pc.Variant.Product.Discount.ExpireDate > DateTime.Now
                        ? 1 - pc.Variant.Product.Discount.DiscountValue / 100
                        : 1) * pc.Quantity);

            // Lưu thay đổi
            await _context.SaveChangesAsync();

            return cartExist;
        }

    }
}
