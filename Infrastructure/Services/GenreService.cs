using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Helper;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public int AddGenre(GenreRequest request)
        {
            Genre genre = new Genre { 
            Name= request.Name
            };
          return genreRepository.Insert(genre);
        }

        public Page<GenreResponse> GetPage(int pageNumber, int pageSize)
        {
          Page<Genre> genreRepoPage=  genreRepository.GetGenreByPagination(pageNumber, pageSize);

            List<GenreResponse> responses = new();
            foreach (Genre item in genreRepoPage.Data)
            {
                GenreResponse genreResponse = new GenreResponse();
                genreResponse.Name = item.Name;
                genreResponse.Id = item.Id;
                responses.Add(genreResponse);
            }
            Page<GenreResponse> page = new Page<GenreResponse>
            {
                TotalRecords = genreRepoPage.TotalRecords,
                PageNumber = pageNumber,
                Data = responses
            };
            return page;
        }
    }
}
