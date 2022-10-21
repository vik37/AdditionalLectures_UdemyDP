using System;

namespace BeyondTheElviseOperator_UdemyDPAdditional_ConsoleApp
{
    internal class MaybeMonadDeom
    {
        public void MyMethod(Person p)
        {
            //string postCode = "UNKNOWN";
            //if(p != null && p.Address != null && p.Address.PostCode != null)
            //    postCode = p.Address.PostCode; // old

            // postCode = p?.Address?.PostCode;  // new - unuseless

            // -----------------------------------------------------

            //string postcode;
            //if(p != null)
            //{
            //    if(HasMedicalRecord(p) && p.Address != null)
            //    {
            //        CheckAddress(p.Address);
            //        if (p.Address.PostCode != null)
            //            postcode = p.Address.PostCode;
            //        else
            //            postcode = "UNKNOWN";
            //    }
            //}

            string postcode = p.With(x => x.Address).With(x => x.PostCode);

            postcode = p.If(HasMedicalRecord)
                        .With(x => x.Address)
                        .Do(CheckAddress)
                        .Return(x => x.PostCode, "UNKNOWN");
        }
        private bool HasMedicalRecord(Person p)
        {
            throw new NotImplementedException();
        }
        private void CheckAddress(Address address)
        {
            throw new NotImplementedException();
        }
        static void Main(string[] args)
        {
            
        }
    }
}
