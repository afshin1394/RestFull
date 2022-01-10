using AutoMapper;
using EFDataAccessLibrary.Commons;
using EFDataAccessLibrary.DataAccess;


using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruthDareGrpcService.Protos;

namespace TruthDareGrpcService.Services
{
    public class QuestionService: Questionaire.QuestionaireBase 
    {
        private readonly ILogger<QuestionService> logger;
        private readonly IMapper mapper;
        private readonly IRepository<EFDataAccessLibrary.Models.Question> repository;
       



        public QuestionService(ILogger<QuestionService> logger,  IMapper mapper, IRepository<EFDataAccessLibrary.Models.Question> repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.repository = repository;
        }


        public async override Task<QuestionResponse> GetAllQuestions (QuestionRequest request, ServerCallContext context)
        {
             IEnumerable<EFDataAccessLibrary.Models.Question> question = repository.GetAll().Result;
             QuestionResponse questionResponse = new QuestionResponse();
             questionResponse.QuestionList.Add(mapper.Map<IEnumerable<EFDataAccessLibrary.Models.Question>, IEnumerable<Question>>(question));
             return await Task.FromResult(questionResponse);
        }


        public async override  Task<StatusMessageQuestion> InsertQuestion(InsertingQuestion question,ServerCallContext Context)
        {

            StatusMessageQuestion status = new StatusMessageQuestion();
            status.Message = "success";
            try 
            {
                var data = mapper.Map<InsertingQuestion, EFDataAccessLibrary.Models.Question>(question);
                repository.Add(data);
                repository.SaveChanges();
            }
            catch(Exception e)
            {
                status.Message = "failed";
            }
            return await Task.FromResult(status);
        }


        public override Task<StatusMessageQuestion> DeleteByIDQuestion(QuestionID questionID, ServerCallContext Context)
        {
            StatusMessageQuestion status = new StatusMessageQuestion();
            status.Message = "success";
            try
            {
                
                var question = repository.GetAll().Result.Where(b => b.Id == questionID.Id);
                repository.Delete(question.FirstOrDefault());      
                repository.SaveChanges();
            }
            catch (Exception exception)
            {
                status.Message = "failed";
            }

            return Task.FromResult(status);
        }

        public override async Task<QuestionResponse> GetQuestionsByCategoryID(CategoryIDRequest request, ServerCallContext context)
        {
            IEnumerable<EFDataAccessLibrary.Models.Question> questions = await repository.FindByID(request.CategoryIDRequest_);
            QuestionResponse questionResponse = new QuestionResponse();
            questionResponse.QuestionList.Add(mapper.Map<IEnumerable<EFDataAccessLibrary.Models.Question>, IEnumerable<Question>>(questions));
            return questionResponse;
        }
    }
}
