using AutoMapper;
using System;
using System.Web;
using System.Web.Mvc;
using Task_1.Entities;
using Task_1.PL.WEB_UI.Models.Recipie;
using Task_1.PL.WEB_UI.Models.File;
using Task_1.PL.WEB_UI.Models.User;

namespace Task_1.PL.WEB_UI
{
    public class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserDTO, UserVM>();

                cfg.CreateMap<RecipieDTO, RecipieVM>();

                cfg.CreateMap<RecipieVM, RecipieDTO>();

                cfg.CreateMap<CreateRecipieVM, RecipieDTO>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Image_id, opt => opt.Ignore());

                cfg.CreateMap<CreateRecipieVM, RecipieVM>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Image_id, opt => opt.Ignore());

                cfg.CreateMap<RecipieVM, CreateRecipieVM>();

                cfg.CreateMap<CreateUserVM, UserDTO>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Age, opt => opt.Ignore())
                    .ForMember(dest => dest.Recipies, opt => opt.Ignore());

                cfg.CreateMap<EditUserVM, UserDTO>()
                    .ForMember(dest => dest.Image_id, opt => opt.ResolveUsing(src => src.HasImage ? src.Image_id : 0))
                    .ForMember(dest => dest.Age, opt => opt.Ignore());

                cfg.CreateMap<UserDTO, EditUserVM>()
                    .ForMember(dest => dest.HasImage, opt => opt.ResolveUsing(src => src.Image_id != 0))
                    .ForMember(dest => dest.Birthdate, opt => opt.ResolveUsing(src => src.Birthdate.ToShortDateString()))
                    .ForMember(dest => dest.SelectedRecipie, opt => opt.Ignore())
                    .ForMember(dest => dest.MissingRecipies, opt => opt.Ignore())
                    .ForMember(dest => dest.SelectedRecipieToDelete, opt => opt.Ignore());

                cfg.CreateMap<ApiEditUserVM, UserDTO>()
                    .ForMember(dest => dest.Age, opt => opt.Ignore());

                cfg.CreateMap<UserDTO, ApiEditUserVM>()
                    .ForMember(dest => dest.Birthdate, opt => opt.ResolveUsing(src => src.Birthdate.ToShortDateString()))
                    .ForMember(dest => dest.SelectedRecipie, opt => opt.Ignore())
                    .ForMember(dest => dest.MissingRecipies, opt => opt.Ignore())
                    .ForMember(dest => dest.SelectedRecipieToDelete, opt => opt.Ignore());

                cfg.CreateMap<FileInfo, ImageDTO>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());

                cfg.CreateMap<RecipieDTO, SelectListItem>()
                    .ForMember(dest => dest.Text, opt => opt.ResolveUsing(src => src.Title))
                    .ForMember(dest => dest.Value, opt => opt.ResolveUsing(src => src.Id))
                    .ForAllOtherMembers(opt => opt.Ignore());
            }

            );
            Mapper.AssertConfigurationIsValid();
        }

    }
}