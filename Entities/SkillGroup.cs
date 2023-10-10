using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UxGame_Testing_Utility.Entities
{
    public readonly record struct SkillGroup(Skill[] Skills) 
    { 
        public int Count => Skills.Length;
    }
    public readonly record struct Skill(string Id, string BulletId, string ShooterId) 
    {
        /// <summary>
        /// judge if given two skills is same skill, but problebly not in same level.
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public static bool IsSame(string id1, string id2) 
        {
            return id1[..3] == id2[..3];
        }
    }
}
