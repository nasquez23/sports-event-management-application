﻿using SportsEvent.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Domain.DTO
{
    public class ShoppingCartDTO
    {
        public List<TicketInShoppingCart>? Tickets { get; set; }
        public double TotalPrice { get; set; }
    }
}
