using System;

namespace heaps
{
    public class Call{

        public DateTime TimeCalled { get; set;}
        public string CallerFirstName {get; set;}
        public string CallerLastName {get; set;}
        public int CallerId { get; set; }
        public Call(){ }

        public Call(DateTime timeCalled, string callerFirstName, string callerLastName, int callerId){
            TimeCalled = timeCalled;
            CallerFirstName = callerFirstName;
            CallerLastName = callerLastName;
            CallerId = callerId;
        }

        public Call GenerateCaller(int id){           
            return new Call(GetRandomTime(), "Caller", "LastName", id);                   
        } 

        private DateTime GetRandomTime(){
            var now = DateTime.Now;
            
            Random random = new Random();
            return now.AddMinutes(-1*(random.Next(60)));
        }
    }    
}