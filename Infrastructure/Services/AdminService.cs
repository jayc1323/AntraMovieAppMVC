using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository userRepository;
        private readonly IMovieRepository movieRepository;

        public AdminService(IUserRepository userRepository, IMovieRepository movieRepository)
        {
            this.userRepository = userRepository;
            this.movieRepository = movieRepository;
        }

        public int AddMovie(MovieRequest request)
        {
            Movie movie = new Movie
            {
                Title = request.Title,
                TmdbUrl = request.TmdbUrl,
                OverView = request.OverView,
                Tagline = request.Tagline,
                OriginalLanguage = request.OriginalLanguage,
                ReleaseDate = request.ReleaseDate,
                RunTime = request.RunTime,
                Budget = request.Budget,
                Revenue = request.Revenue,
                BackdropUrl = request.BackdropUrl,
                PosterUrl = request.PosterUrl,
                ImdbUrl = request.ImdbUrl
            };
            return movieRepository.Insert(movie);
        }

        public IEnumerable<UserResponse> GetAllUsers()
        {
            return userRepository.GetAll().Select(u => new UserResponse
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                IsLocked = u.IsLocked,
                DateOfBirth = u.DateOfBirth
            }).ToList();
        }

        public bool LockUser(int userId)
        {
            User user = userRepository.GetById(userId);
            if (user == null) return false;
            user.IsLocked = true;
            userRepository.Update(user);
            return true;
        }

        public bool UnlockUser(int userId)
        {
            User user = userRepository.GetById(userId);
            if (user == null) return false;
            user.IsLocked = false;
            userRepository.Update(user);
            return true;
        }
    }
}
