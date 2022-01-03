using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOlayer.Collections;
using DomainLayer.Model;
using DTOlayer.Collections.Cart;
using DTOlayer.Collections.CartDetail;
using DTOlayer.Collections.Category;
using DTOlayer.Collections.CategoryDetail;
using DTOlayer.Collections.Color;
using DTOlayer.Collections.Company;
using DTOlayer.Collections.ConfirmOrder;
using DTOlayer.Collections.Contact;
using DTOlayer.Collections.Menu;
using DTOlayer.Collections.Message;
using DTOlayer.Collections.Post;
using DTOlayer.Collections.Product;
using DTOlayer.Collections.Product_Type;
using DTOlayer.Collections.ProductImages;
using DTOlayer.Collections.ProductDetail;
using DTOlayer.Collections.ProductReview;
using DTOlayer.Collections.Slide;
using DTOLayer.Collections.User;

namespace DTOLayer
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            CreateMap<CartToAdd, Cart>().ReverseMap();
            CreateMap<CartToUpdate, Cart>().ReverseMap();
            CreateMap<CartToGet, Cart>().ReverseMap();

            CreateMap<CartDetailToAdd, CartDetail>().ReverseMap();
            CreateMap<CartDetailToGet, CartDetail>().ReverseMap();
            CreateMap<CartDetailToUpdate, CartDetail>().ReverseMap();
            CreateMap<CartDetailToUpdate, CartDetailToGet>().ReverseMap();

            CreateMap<CategoryToGet, Category>().ReverseMap();
            CreateMap<CategoryToAdd, Category>().ReverseMap();
            CreateMap<CategoryToUpdate, Category>().ReverseMap();

            CreateMap<CategoryDetailToUpdate, CategoryDetail>().ReverseMap();
            CreateMap<CategoryDetailToGet, CategoryDetail>().ReverseMap();
            CreateMap<CategoryDetailToAdd, CategoryDetail>().ReverseMap();

            CreateMap<ColorToGet, Color>().ReverseMap();
            CreateMap<ColorToAdd, Color>().ReverseMap();
            CreateMap<ColorToUpdate, Color>().ReverseMap();

            CreateMap<CompanyToGet, Company>().ReverseMap();
            CreateMap<CompanyToAdd, Company>().ReverseMap();
            CreateMap<CompanyToUpdate, Company>().ReverseMap();

            CreateMap<ConfirmOrderToUpdate, ConfirmOrder>().ReverseMap();
            CreateMap<ConfirmOrderToGet, ConfirmOrder>().ReverseMap();
            CreateMap<ConfirmOrderToAdd, ConfirmOrder>().ReverseMap();

            CreateMap<ContactToGet, Contact>().ReverseMap();
            CreateMap<ContactToAdd, Contact>().ReverseMap();
            CreateMap<ContactToUpdate, Contact>().ReverseMap();

            CreateMap<MenuToGet, Menu>().ReverseMap();
            CreateMap<MenuToAdd, Menu>().ReverseMap();
            CreateMap<MenuToUpdate, Menu>().ReverseMap();

            CreateMap<MessageToAdd, Message>().ReverseMap();
            CreateMap<MessageToGet, Message>().ReverseMap();
            CreateMap<MessageToUpdate, Message>().ReverseMap();

            CreateMap<PostToGet, Post>().ReverseMap();
            CreateMap<PostToAdd, Post>().ReverseMap();
            CreateMap<PostToUpdate, Post>().ReverseMap();

            CreateMap<ProductToAdd, Product>().ReverseMap();
            CreateMap<ProductToGet, Product>().ReverseMap();
            CreateMap<ProductToUpdate, Product>().ReverseMap();

            CreateMap<Product_TypeToAdd, Product_Type>().ReverseMap();
            CreateMap<Product_TypeToGet, Product_Type>().ReverseMap();
            CreateMap<Product_TypeToUpdate, Product_Type>().ReverseMap();

            CreateMap<ProductImagesToUpdate, ProductImages>().ReverseMap();
            CreateMap<ProductImagesToAdd, ProductImages>().ReverseMap();
            CreateMap<ProductImagesToGet, ProductImages>().ReverseMap();

            CreateMap<ProductDetailToAdd, ProductDetail>().ReverseMap();
            CreateMap<ProductDetailToGet, ProductDetail>().ReverseMap();
            CreateMap<ProductDetailToUpdate, ProductDetail>().ReverseMap();

            CreateMap<ProductReviewToAdd, ProductReview>().ReverseMap();
            CreateMap<ProductReviewToUpdate, ProductReview>().ReverseMap();
            CreateMap<ProductReviewToGet, ProductReview>().ReverseMap();

            CreateMap<SlideToAdd, Slide>().ReverseMap();
            CreateMap<SlideToGet, Slide>().ReverseMap();
            CreateMap<SlideToUpdate, Slide>().ReverseMap();

            CreateMap<UserToAdd, User>().ReverseMap();
            CreateMap<UserToGet, User>().ReverseMap();
            CreateMap<UserToUpdate, User>().ReverseMap();
        }
    }
}
