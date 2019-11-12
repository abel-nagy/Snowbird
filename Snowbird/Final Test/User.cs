using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Test {
    public class User {

        private string username, userid;

        public User(string username, string userid) {
            this.username = username;
            this.userid = userid;
        }

        public string Username {
            get { return username; }
        }
        public string Userid {
            get { return userid; }
        }

    }
}
