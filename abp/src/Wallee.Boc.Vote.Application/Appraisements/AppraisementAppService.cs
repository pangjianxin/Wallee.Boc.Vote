using AutoFilterer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Wallee.Boc.Vote.Appraisements
{
    public class AppraisementAppService :
        CrudAppService<Appraisement, AppraisementDto, Guid, GetAppraisementsInputDto, AppraisementCreateDto, AppraisementUpdateDto>,
        IAppraisementAppService, ITransientDependency
    {
        public AppraisementAppService(IAppraisementRepository appraisementRepository) : base(appraisementRepository)
        {
            AppraisementRepository = appraisementRepository;
        }

        public IAppraisementRepository AppraisementRepository { get; }

        public async override Task<AppraisementDto> CreateAsync(AppraisementCreateDto input)
        {
            var appraisement = new Appraisement(GuidGenerator.Create(),
                input.Name,
                input.Description,
                input.Category,
                input.Start,
                input.End);

            await AppraisementRepository.InsertAsync(appraisement);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<Appraisement, AppraisementDto>(appraisement);

        }

        /// <summary>
        /// 获取所有目前可用的活动
        /// </summary>
        /// <returns></returns>
        public async Task<List<AppraisementDto>> GetAllAvailableAsync()
        {
            var list = (await AppraisementRepository.GetQueryableAsync()).Where(it => it.End >= Clock.Now);

            var result = await AsyncExecuter.ToListAsync(list);

            return ObjectMapper.Map<List<Appraisement>, List<AppraisementDto>>(result);
        }


        public async override Task<AppraisementDto> UpdateAsync(Guid id, AppraisementUpdateDto input)
        {
            var appraisement = await AppraisementRepository.GetAsync(id);
            appraisement.ConcurrencyStamp = input.ConcurrencyStamp;
            appraisement.SetName(input.Name);
            appraisement.SetDescription(input.Description);
            appraisement.SetStart(input.Start);
            appraisement.SetEnd(input.End);
            appraisement.SetCategory(input.Category);
            await AppraisementRepository.UpdateAsync(appraisement);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<Appraisement, AppraisementDto>(appraisement);
        }

        protected override async Task<IQueryable<Appraisement>> CreateFilteredQueryAsync(GetAppraisementsInputDto input)
        {
            return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
        }
    }
}
