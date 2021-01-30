using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace Job.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Attachment
    {
        [Key]
        public string resource { get; set; }
        public string address { get; set; }
        public string path { get; set; }
        public string caption { get; set; }
    }

    public class PrefilledStatus
    {
        [Key] 
        public string status { get; set; }
    }

    public class StatsJob
    {
        [Key] 
        public int finishedApplications { get; set; }
    }

    public class Persona
    {
        [Key] 
        public string id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public bool hasEmail { get; set; }
        public string professionalHeadline { get; set; }
        public string picture { get; set; }
        public bool hasBio { get; set; }
        public double bioCompletion { get; set; }
        public double weight { get; set; }
        public bool verified { get; set; }
        public string pictureThumbnail { get; set; }
        public int? subjectId { get; set; }
    }

    public class Member
    {
        [Key] 
        public string id { get; set; }
        public Persona persona { get; set; }
        public bool manager { get; set; }
        public bool poster { get; set; }
        public bool member { get; set; }
        public string status { get; set; }
        public bool visible { get; set; }
        public bool screeningQuestionsTipClosed { get; set; }
    }

    public class Detail
    {
        [Key] 
        public string code { get; set; }
        public string content { get; set; }
    }

    public class Place
    {
        [Key] 
        public bool remote { get; set; }
        public bool anywhere { get; set; }
        public bool timezone { get; set; }
        public List<object> location { get; set; }
    }

    public class Identifier
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        
        [Key]
        public string name { get; set; }
        public string value { get; set; }
    }

    public class HiringOrganization
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        
        [Key]
        public string name { get; set; }
        public string logo { get; set; }
    }

    public class ApplicantLocationRequirement
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        
        [Key]
        public string name { get; set; }
    }

    public class Value
    {
        [JsonProperty("@type")]
        
        [Key]
        public string Type { get; set; }
        public int minValue { get; set; }
        public int maxValue { get; set; }
        public string unitText { get; set; }
    }

    public class BaseSalary
    {
        [JsonProperty("@type")]
        [Key]
        public string Type { get; set; }
        public string currency { get; set; }
        public Value value { get; set; }
    }

    public class SerpTags
    {
        [JsonProperty("@context")]
        public string Context { get; set; }
        [JsonProperty("@type")]
        [Key]
        public string Type { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Identifier identifier { get; set; }
        public DateTime datePosted { get; set; }
        public List<string> employmentType { get; set; }
        public DateTime validThrough { get; set; }
        public HiringOrganization hiringOrganization { get; set; }
        public string jobLocationType { get; set; }
        public List<ApplicantLocationRequirement> applicantLocationRequirements { get; set; }
        public BaseSalary baseSalary { get; set; }
    }

    public class Owner
    {
        [Key]
        public string id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public bool hasEmail { get; set; }
        public string professionalHeadline { get; set; }
        public string picture { get; set; }
        public string pictureThumbnail { get; set; }
        public bool hasBio { get; set; }
        public double bioCompletion { get; set; }
        public int weight { get; set; }
        public bool verified { get; set; }
        public int subjectId { get; set; }
    }

    public class Agreement
    {
        [Key]
        public string type { get; set; }
    }

    public class Language2
    {
        [Key]
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Languages
    {
        public Languages languages { get; set; }
        [Key]
        public string fluency { get; set; }
    }

    public class Commitment
    {
        [Key]
        public string code { get; set; }
        public int hours { get; set; }
    }

    public class Strengths
    {
        [Key]
        public string id { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public string experience { get; set; }
    }

    public class Organizations
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public string picture { get; set; }
    }

    public class Compensation
    {
        [Key]
        public string code { get; set; }
        public string currency { get; set; }
        public bool estimate { get; set; }
        public int minAmount { get; set; }
        public int maxAmount { get; set; }
        public string periodicity { get; set; }
        public bool visible { get; set; }
    }

    public class Advertisement
    {
        public List<Attachment> attachments { get; set; }
        public int boardVersion { get; set; }
        public PrefilledStatus prefilledStatus { get; set; }
        public string locale { get; set; }
        public string objective { get; set; }
        public StatsJob statsjob { get; set; }
        public string review { get; set; }
        public object draft { get; set; }
        public List<Member> members { get; set; }
        public List<Detail> details { get; set; }
        [Key] 
        public string id { get; set; }
        public Place place { get; set; }
        public DateTime deadline { get; set; }
        public string slug { get; set; }
        public SerpTags serpTags { get; set; }
        public Owner owner { get; set; }
        public double completion { get; set; }
        public Agreement agreement { get; set; }
        public List<Languages> languages { get; set; }
        public DateTime created { get; set; }
        public bool crawled { get; set; }
        public string opportunity { get; set; }
        public bool active { get; set; }
        public Commitment commitment { get; set; }
        public DateTime stableOn { get; set; }
        public List<string> timezones { get; set; }
        public List<Strengths> strengths { get; set; }
        public List<Organizations> organizations { get; set; }
        public Compensation compensation { get; set; }
        public string openGraph { get; set; }
        public string status { get; set; }
    }


}