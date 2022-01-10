using AutoMapper;
using EFDataAccessLibrary.Commons;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruthDareGrpcService.Dare.Protos;

namespace TruthDareGrpcService.Dare.Protos
{
    public class DareService : Dare.DareBase
    {
        private readonly ILogger<DareService> logger;
        private readonly IMapper mapper;
        private readonly IRepository<EFDataAccessLibrary.Models.Dare> repository;




        public DareService(ILogger<DareService> logger, IMapper mapper, IRepository<EFDataAccessLibrary.Models.Dare> repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.repository = repository;
        }

        public async override Task<DareResponse> GetAllDares(DareRequest request, ServerCallContext context)
        {

            IEnumerable<EFDataAccessLibrary.Models.Dare> dares = repository.GetAll().Result;
            DareResponse dareResponse = new DareResponse();
            dareResponse.DareList.Add(mapper.Map<IEnumerable<EFDataAccessLibrary.Models.Dare>, IEnumerable<DareModel>>(dares));
            return await Task.FromResult(dareResponse);

        }


        public async override Task<StatusMessageDare> InsertDare(InsertingDare question, ServerCallContext Context)
        {

            StatusMessageDare status = new StatusMessageDare();
            status.Message = "success";
            try
            {
                var data = mapper.Map<InsertingDare, EFDataAccessLibrary.Models.Dare>(question);
                repository.Add(data);
                repository.SaveChanges();
            }
            catch (Exception e)
            {
                status.Message = "failed";
            }
            return await Task.FromResult(status);
        }


        public override Task<StatusMessageDare> DeleteByIDDare(DareID dareID, ServerCallContext Context)
        {
            StatusMessageDare status = new StatusMessageDare();
            status.Message = "success";
            try
            {

                var question = repository.GetAll().Result.Where(b => b.Id == dareID.Id);
                repository.Delete(question.FirstOrDefault());
                repository.SaveChanges();
            }
            catch (Exception exception)
            {
                status.Message = "failed";
            }

            return Task.FromResult(status);
        }

        public override async Task<DareResponse> GetDaresByCategoryId(CaregoryIDRequest request, ServerCallContext context)
        {

            IEnumerable<EFDataAccessLibrary.Models.Dare> dares = await repository.FindByID(request.CategoryIDRequest);
            DareResponse dareResponse = new DareResponse();
            dareResponse.DareList.Add(mapper.Map<IEnumerable<EFDataAccessLibrary.Models.Dare>, IEnumerable<DareModel>>(dares));
            return dareResponse;
        }
    }
}
