﻿using Portfolio_API.DTOs;
using Portfolio_API.Models;

namespace Portfolio_API.Repository.Repository_Interface
{
    public interface IAbout
    {
        public About GetAbout (int id);

        public void AddAbout (int id, About about);

        public void removeAbout (int id);

        public void updateAbout (int id, AboutDto about);
    }
}