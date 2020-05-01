﻿using AutoMapper;
using DFC.App.JobCategories.Data.Models;
using DFC.App.JobCategories.Data.ServiceBusModels;
using Newtonsoft.Json;

namespace DFC.App.JobCategories.MessageFunctionApp.Services
{
    public class MappingService : IMappingService
    {
        private readonly IMapper mapper;

        public MappingService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ContentPageModel MapToContentPageModel(string message, long sequenceNumber)
        {
            var fullMessage = JsonConvert.DeserializeObject<ContentPageMessage>(message);
            var contentPageModel = mapper.Map<ContentPageModel>(fullMessage);
            contentPageModel.SequenceNumber = sequenceNumber;

            return contentPageModel;
        }
    }
}