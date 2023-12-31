﻿using NPOI.Util.ArrayExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UxGame_Testing_Utility.Entities
{
    public readonly record struct SkillGroup(Skill[] Skills, string Name) 
    { 
        public int Count => Skills.Length;

        public override string ToString()
        {
            string msg = $"{Name}";

            Array.ForEach(
                Skills,
                skill => msg += $" · {skill}"
                );
            return msg;
        }
    }
    public readonly record struct Skill(string Id, string BulletId, string ShooterId) 
    {
        /// <summary>
        /// judge if given two skills is same skill, but problebly not in same level.
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsSameGroup(string id1, string id2) 
        {
            if (id1.Length < 3 || id2.Length < 3)
                return false;

            return id1[..3] == id2[..3];
        }

        public override string ToString()
        {
            return $"id: {this.Id}, bullet: {this.BulletId}, shooter: {this.ShooterId}";
        }
    }
}
