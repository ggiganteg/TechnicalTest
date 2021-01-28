using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Genoma.Models
{
    public class Person
    {
        [Key]
        public int subjectId { get; set; }
        public string professionalHeadline { get; set; }
        public double completion { get; set; }
        public bool showPhone { get; set; }
        public DateTime created { get; set; }
        public bool verified { get; set; }
        public Flags flags { get; set; }
        public int weight { get; set; }
        public string locale { get; set; }
        public string picture { get; set; }
        public bool hasEmail { get; set; }
        public bool isTest { get; set; }
        public string name { get; set; }
        public List<Link> links { get; set; }
        public Location location { get; set; }
        public string theme { get; set; }
        public string id { get; set; }
        public string pictureThumbnail { get; set; }
        public bool claimant { get; set; }
        public string summaryOfBio { get; set; }
        public string weightGraph { get; set; }
        public string publicId { get; set; }
    }
 
    public class Flags
    {
        [Key] 
        public bool benefits { get; set; }
        public bool canary { get; set; }
        public bool enlauSource { get; set; }
        public bool fake { get; set; }
        public bool featureDiscovery { get; set; }
        public bool getSignaledBenefitsViewed { get; set; }
        public bool firstSignalSent { get; set; }
        public bool promoteYourselfBenefitsViewed { get; set; }
        public bool promoteYourselfCompleted { get; set; }
        public bool importingLinkedin { get; set; }
        public bool onBoarded { get; set; }
        public bool remoter { get; set; }
        public bool signalsFeatureDiscovery { get; set; }
        public bool signedInToOpportunities { get; set; }
        public bool importingLinkedinRecommendations { get; set; }
        public bool contactsImported { get; set; }
        public bool appContactsImported { get; set; }
        public bool genomeCompletionAcknowledged { get; set; }
    }

    public class Link
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }

    public class Location
    {
        [Key] 
        public string name { get; set; }
        public string country { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public int timezoneOffSet { get; set; }
    }

     public class Stats
    {
        [Key] 
        public int jobs { get; set; }
        public int education { get; set; }
        public int strengths { get; set; }
        public int interests { get; set; }
    }

    public class Strength
    {
        [Key] 
        public string id { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public string additionalInfo { get; set; }
        public int weight { get; set; }
        public int recommendations { get; set; }
        public List<object> media { get; set; }
        public DateTime created { get; set; }
    }

    public class Interest
    {
        [Key] 
        public string id { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public List<object> media { get; set; }
        public DateTime created { get; set; }
    }

    public class Organization
    {
        [Key] 
        public int id { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
    }

    public class Experience
    {
        [Key] 
        public string id { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public List<Organization> organizations { get; set; }
        public List<object> responsibilities { get; set; }
        public string fromMonth { get; set; }
        public string fromYear { get; set; }
        public string additionalInfo { get; set; }
        public bool highlighted { get; set; }
        public int weight { get; set; }
        public int verifications { get; set; }
        public int recommendations { get; set; }
        public List<object> media { get; set; }
        public int rank { get; set; }
        public string toMonth { get; set; }
        public string toYear { get; set; }
    }

    public class Job
    {
        [Key] 
        public string id { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public List<Organization> organizations { get; set; }
        public List<object> responsibilities { get; set; }
        public string fromMonth { get; set; }
        public string fromYear { get; set; }
        public string additionalInfo { get; set; }
        public bool highlighted { get; set; }
        public int weight { get; set; }
        public int verifications { get; set; }
        public int recommendations { get; set; }
        public List<object> media { get; set; }
        public int rank { get; set; }
        public string toMonth { get; set; }
        public string toYear { get; set; }
    }

    public class Education
    {
        [Key] 
        public string id { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public List<Organization> organizations { get; set; }
        public List<object> responsibilities { get; set; }
        public bool highlighted { get; set; }
        public int weight { get; set; }
        public int verifications { get; set; }
        public int recommendations { get; set; }
        public List<object> media { get; set; }
        public int rank { get; set; }
        public string fromMonth { get; set; }
        public string fromYear { get; set; }
        public string toMonth { get; set; }
        public string toYear { get; set; }
        public string additionalInfo { get; set; }
    }

    public class Opportunity
    {
        [Key] 
        public string id { get; set; }
        public string interest { get; set; }
        public string field { get; set; }
        public object data { get; set; }
    }

    public class Language
    {
        [Key] 
        public string code { get; set; }
        public string language { get; set; }
        public string fluency { get; set; }
    }

    public class Group
    {
        [Key]
        public string id { get; set; }
        public int order { get; set; }
        public double median { get; set; }
        public double stddev { get; set; }
        public string text { get; set; }
        public string answer { get; set; }
    }

    public class Analysis
    {
        [Key]
        public string groupId { get; set; }
        public double analysis { get; set; }
        public string section { get; set; }
    }

    public class PersonalityTraitsResults
    {
        [Key]
        public string PTId { get; set; }
        public List<Group> groups { get; set; }
        public List<Analysis> analyses { get; set; }
    }

    public class ProfessionalCultureGenomeResults
    {
        [Key]
        public string PCId { get; set; }
        public List<Group> groups { get; set; }
        public List<Analysis> analyses { get; set; }
    }

    public class Candidate
    {
        [Key]
        public string CandidateId { get; set; }
        public Person person { get; set; }
        public Stats stats { get; set; }
        public List<Strength> strengths { get; set; }
        public List<Interest> interests { get; set; }
        public List<Experience> experiences { get; set; }
        public List<object> awards { get; set; }
        public List<Job> jobs { get; set; }
        public List<object> projects { get; set; }
        public List<object> publications { get; set; }
        public List<Education> education { get; set; }
        public List<Opportunity> opportunities { get; set; }
        public List<Language> languages { get; set; }
        public PersonalityTraitsResults personalityTraitsResults { get; set; }
        public ProfessionalCultureGenomeResults professionalCultureGenomeResults { get; set; }
    }


}