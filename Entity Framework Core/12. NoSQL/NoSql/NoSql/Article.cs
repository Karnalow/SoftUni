﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSql
{
    public class Article : BsonDocument
    {
        [BsonElement]
        public string Name { get; set; }
    }
}