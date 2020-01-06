﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardDto
    {
        [Required]
        [RegularExpression(@"[0-9]{4}\s+[0-9]{4}\s+[0-9]{4}\s+[0-9]{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}")]
        public string Cvc { get; set; }

        public CardType Type { get; set; }
    }
}
