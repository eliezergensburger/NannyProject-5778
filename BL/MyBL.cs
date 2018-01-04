using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

using System.Text.RegularExpressions;
using System.Threading;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi.Entities.Elevation.Request;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using GoogleMapsApi.StaticMaps;
using GoogleMapsApi.StaticMaps.Entities;

namespace BL
{
    public class MyBL : Ibl
    {
        public int addMother(Mother m)
        {
            IDal dal = DAL.FactorysingletonDal.getInstance;
            return dal.addMother(m);
        }

        public int addContract(Contract c)
        {
            IDal dal = DAL.FactorysingletonDal.getInstance;
            return dal.addContract(c);

        }
        public bool removeMother(Mother m)
        {
            IDal dal = DAL.FactorysingletonDal.getInstance;
            return dal.removeMother(m);
        }

        public List<Mother> getAllMothers(Func<Mother, bool> filter = null)
        {
            List<Mother> result;
            IDal dal = DAL.FactorysingletonDal.getInstance;
            if (filter == null)
            {
                result = dal.getAllMothers().ToList();
            }
            else
            {
                //  result = dal.getAllMothers().Where(filter).ToList();
                result = (from m in dal.getAllMothers()
                          where filter(m)
                          select m).ToList();
            }
            return result;
        }

        public List<Contract> getAllContracts(Func<Contract, bool> filter = null)
        {
            List<Contract> result;
            IDal dal = DAL.FactorysingletonDal.getInstance;
            if (filter == null)
            {
                result = dal.getAllContracts().ToList();
            }
            else
            {
                //  result = dal.getAllContracts().Where(filter).ToList();
                result = (from m in dal.getAllContracts()
                          where filter(m)
                          select m).ToList();
            }
            return result;
        }

        private static Leg PrintDirections(DirectionsResponse directions,bool printdetails =true)
        {
            Route route = directions.Routes.First();
            Leg leg = route.Legs.First();
            //string result = leg.Distance.Text;
            if (printdetails == true)
            {
                foreach (Step step in leg.Steps)
                {
                    Console.WriteLine(StripHTML(step.HtmlInstructions));

                    var localIcon = step.TransitDetails?.Lines?.Vehicle?.LocalIcon;
                    if (localIcon != null)
                        Console.WriteLine("Local sign: " + localIcon);
                }
                Console.WriteLine();
            }
            return leg;
        }

        private static string StripHTML(string html)
        {
            return Regex.Replace(html, @"<(.|\n)*?>", string.Empty);
        }

        public int getWalkingDistance(string source, string target, bool withdirections)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = target
               // Destination = "31.8414894,35.2471631"
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Leg leg = PrintDirections(drivingDirections, withdirections);

            return (leg.Distance.Value);
        }
        public int getDrivingDistance(string source, string target,bool withdirections)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Driving,
                Origin = source,
                Destination = target
                // Destination = "31.8414894,35.2471631"
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Leg leg = PrintDirections(drivingDirections, withdirections);

            return (leg.Distance.Value);
        }

    }
}
