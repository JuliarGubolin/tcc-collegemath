﻿using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Interfaces;

namespace CollegeMath.Application.Applications
{
    public class ImageQuestionApplication : IImageQuestionApplication
    {
        IImageQuestionRepository _imageQuestionRepository;

        public ImageQuestionApplication(IImageQuestionRepository imageQuestionRepository)
        {
            _imageQuestionRepository = imageQuestionRepository;
        }

        public IEnumerable<ImageQuestionDTO> GetAll()
        {
            return _imageQuestionRepository.GetAll().Select(c => new ImageQuestionDTO
            {
                Id = c.Id,
                CreatedDate = c.CreatedDate,
                QuestionId = c.QuestionId,
                Url = c.Url
            });
        }

        public void Insert(ImageQuestionDTO imageQuestionDTO)
        {
            var imageQuestion = new ImageQuestion(imageQuestionDTO.QuestionId, imageQuestionDTO.Url);
            _imageQuestionRepository.Insert(imageQuestion);
        }

        public void Update( ImageQuestionDTO imageQuestionDTO)
        {
            var ImageQuestion = _imageQuestionRepository.Find(imageQuestionDTO.Id);
            ImageQuestion.Url = imageQuestionDTO.Url;
            ImageQuestion.QuestionId = imageQuestionDTO.QuestionId;
            _imageQuestionRepository.Update(ImageQuestion);
        }
    }
}
