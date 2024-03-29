﻿using Return = Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edutor.Web.Api.Models;
using Edutor.Data;
using Edutor.Data.QueryProcessors;
using Edutor.Common.TypeMapping;
using Edutor.Web.Api.LinkServices;

namespace Edutor.Web.Api.InquiryProcessing
{
    public interface IGetGroupsInquiryProcessor
    {

        PagedDataResponse<Return.Group> GetAllGroups(PagedDataRequest request);
        PagedDataResponse<Return.Group> GetGroupsForSchoolUser(int schoolUserId, PagedDataRequest request);
        Return.Group GetGroup(int groupId);

        Return.Group GetGroup(string name);
    }

    public class GetGroupsInquiryProcessor : IGetGroupsInquiryProcessor
    {

        private readonly IAutoMapper _autoMapper;
        private readonly IGetGroupsQueryProcessor _queryProcessor;
        private readonly IGroupsLinkService _groupsLinkServicces;
        private readonly ICommonLinkService _commonLinkService;

        public GetGroupsInquiryProcessor(IAutoMapper autoMapper,
            IGroupsLinkService tutorsLinkService,
            IGetGroupsQueryProcessor queryProcessor, 
            ICommonLinkService commonLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _commonLinkService = commonLinkService;
            _groupsLinkServicces = tutorsLinkService;
        }

        public PagedDataResponse<Return.Group> GetAllGroups(PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetGroups(request);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataResponse<Return.Group>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }


        private List<Return.Group> GetCollection(QueryResult<Data.Entities.Group> qresult)
        {
            var x = qresult.QueriedItems.Select(r => _autoMapper.Map<Return.Group>(r)).ToList();
            x.ForEach(t => _groupsLinkServicces.AddAllLinks(t));
            return x;
        }

        public PagedDataResponse<Return.Group> GetGroupsForSchoolUser(int schoolUser,PagedDataRequest request)
        {
            var qresult = _queryProcessor.GetGroupsForSchoolUser(schoolUser, request);
            var returnUsers = GetCollection(qresult);
            var inquiryResponse = new PagedDataResponse<Return.Group>
            {
                Items = returnUsers,
                PageCount = qresult.TotalPageCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            _commonLinkService.AddPageLinks(inquiryResponse);

            return inquiryResponse;
        }


        public Return.Group GetGroup(int groupId)
        {
            var s = _queryProcessor.GetGroup(groupId);
            var returnType = _autoMapper.Map<Return.Group>(s);
            _groupsLinkServicces.AddAllLinks(returnType);
            return returnType;
        }




        public Return.Group GetGroup(string name)
        {
            var s = _queryProcessor.GetGroup(name);
            var returnType = _autoMapper.Map<Return.Group>(s);
            _groupsLinkServicces.AddAllLinks(returnType);
            return returnType;
        }
    }
}

