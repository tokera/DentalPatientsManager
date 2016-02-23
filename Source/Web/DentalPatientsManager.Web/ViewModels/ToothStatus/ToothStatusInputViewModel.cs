namespace DentalPatientsManager.Web.ViewModels.ToothStatus
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ToothStatusInputViewModel : IMapFrom<ToothStatus>
    {
        [Display(Name = "Статус")]
        public string Status { get; set; }

        [Display(Name = "Диагноза")]
        [DataType(DataType.MultilineText)]
        public string Diagnose { get; set; }

        [Display(Name = "Лечебен план")]
        [DataType(DataType.MultilineText)]
        public string TreatmentPlan { get; set; }

        public int PatientId { get; set; }
        
    }
}