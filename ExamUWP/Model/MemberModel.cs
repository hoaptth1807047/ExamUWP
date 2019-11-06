using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamUWP.Entity;
using ExamUWP.Utils;
using SQLitePCL;

namespace ExamUWP.Model
{
    class MemberModel
    {
        public bool Insert(Member member)
        {
            try
            {
                using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("INSERT INTO Member (Name, Phone) VALUES (?,?)"))
                {
                    stt.Bind(1, member.Name);
                    stt.Bind(2, member.Phone);
                    stt.Step();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public ObservableCollection<Member> ReadListMembers()
        {
            ObservableCollection<Member> list = new ObservableCollection<Member>();

            using (var conn = new SQLiteConnection("contact.db", SQLiteOpen.READWRITE))
            {
                using (var statement = conn.Prepare(@"Select * from Member;"))
                {
                    while (statement.Step() == SQLiteResult.ROW)
                    {
                        list.Add(new Member()
                        {
                            Name = (string)statement[1],
                            Phone = (int)statement[2],
                        });
                    }
                }
            }
            return list;
        }
    }
}
