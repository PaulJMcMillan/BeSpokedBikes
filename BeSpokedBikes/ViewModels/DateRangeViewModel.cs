﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.ViewModels
{
    public class DateRangeViewModel
    {
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }

}
