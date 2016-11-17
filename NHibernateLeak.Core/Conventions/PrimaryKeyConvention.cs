using System.Collections.Generic;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace NHibernateLeak.Core.Conventions
{
	public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            //instance.GeneratedBy.HiLo("20");
            //instance.UnsavedValue("null");

            // set options for Mod_, LT_, and Cat_ table names using list objects
            List<string> mods = new List<string>();
            mods.AddRange(new string[] {"CallTime","Case","ContactImport", "ContactOrganization",
                                        "Contact","ContactFlag","Contribution","ContributionDetail", 
                                        "Payment","PhoneBankCall","PhoneBankSession","PreferredWorkType",
                                        "PreferredWorkSchedule","Profile","Shift","ContactSkill","SocialNetwork",
                                        "VoterPhoneBankSession","VoterPhoneBankVoter","WorkHour",
                                        "CanvasserTallySheet","NewRegistrant",
                                        "VoterPhoneBankAssignment","VoterPhoneBankCaller","VoterPhoneBankCall","VoterPhoneBankSession",
                                        "MemberWorkSite",
                                        "MemberWorkSiteRole",
                                        "MemberOrganizationRole",
                                        "CalendarEventInvitation",
                                        "ContactMatchResult",
                                        "ContactImportOrgMapping",
                                        "ContactImportFile",
                                        "ContactImportFileChunk",
                                        "ContactImportColumn",
                                        "ContactImportMapping",
                                        "ContactImportSavedView",
                                        "ContactImportSavedMapping",
                                        "ContactImportIOFile",
                                        "ContactImportConfiguration",
                                        "ContactImportCatalistFile",
                                        "ContactImportPdiFile",
                                        "ContactImportDbMapping",
                                        "CaseDetail",
                                        "CalendarEventShiftAssignment"
            });

            // This maps to module.cat_* under module schema
            List<string> cats = new List<string>();
            cats.AddRange(new string[] {"Activity","DataSource","Event",
                                        "FileLayoutColumnPair","FileLayout","Flag","FlagGroup","Location",
                                        "ModuleOrganization", "OrgNamedPrecincts", "PaymentSource","PhoneBank","ResponseCode",
                                        "ResponseSetMember","ResponseSet","Skill","Solicitor","VoterPhoneBankScript",
                                        "VoterPhoneBank","WorkType","VolunteerOrganization","VolunteerOrganizer",
                                        "Script", "CanvassTarget","CanvassTask",
                                        "VoterPhoneBankLink","VoterPhoneBankTarget","VoterPhoneBankCall",
                                        "ShiftStatus",
                                        "LaborCouncil","WorkLocation","JobClassification",
                                        "ContributionMethod",
                                        "GoogleServiceAccount","GoogleCalendar","CalendarEvent","CalendarGroup",
                                        "CaseCategory",
                                        "EditContactUserPanel",
                                        "EventType",
                                        "InvitationList",
                                        "InvitationListUse",
                                        "InvitationListItem",
                                        "CalendarEventShift",
                                        "InvitationMethod",
                                        "RSVPStatus",

                                        "OrganizationHierarchy",
                                        "OrganizationLevel",
                                        "CommonName",
                                        "Occupation",
                                        "WorkSite",
                                        "WorkSiteLocalCouncil",
                                        "MemberRole",
                                        "Employer",
                                        "EmployerDepartment",
                                        "MemberStatusType",
                                        "MemberShiftType",
                                        "MemberType",
                                        "OrganizationRole",
                                        "WorkSiteEmployer",
                                        "OrganizationView","OrganizationViewDetail"
            });

            ////////// This maps to occ.cat_* under occ schema
            ////////List<string> occ_cats = new List<string>();
            ////////occ_cats.AddRange(new string[] {

            ////////});

            ////////// This maps to occ.LT_* under occ schema
            ////////List<string> occ_lts = new List<string>();
            ////////occ_lts.AddRange(new string[] {
            ////////    "MeetingFrequency"
            ////////});

            List<string> lookups = new List<string>();
            lookups.AddRange(new string[] {"CallOutcome","CallTimeOption","CampaignFunction","ContributionType","DonationMaximum",
                                        "EntityType","FileType","FlagSource","OrganizationTitle","PaymentCategory","PaymentSourceType",
                                        "PaymentType","ProfileType","Report","ShiftRecurrenceOption","ShiftUpdateOption","SocialNetworkType",
                                        "TimeSlot","TimeToCall","VoterPhoneBankFilter","WorkScheduleOption",
                                        "WorkTypeDefault","PledgeRecurrenceOption",
                                        "ScriptType"});

            List<string> mqe = new List<string>();
            mqe.AddRange(new string[] {"MQEControlType", "MQEControl", "MQEDataType", "MQEDatabaseType", "MQEQuery", 
                                    "MQEQueryCategory", "MQEQueryDefinition", "MQEQueryGroupMember", "MQEQueryGroup", "MQEQueryOperator", 
                                    "MQEQuerySelectByType", "MQEQueryTableJoin", "MQEQueryTable" });

            List<string> cr = new List<string>();
            cr.AddRange(new string[] {"DefaultField", "DefaultFieldOption", "DefaultFieldSetUser", "DisplayOption", "Element", 
                                    "Group", "GroupType", "Layout", "SelectedStaticColumn" });

            if (mods.Contains(instance.EntityType.Name))
            {
                // check for plural 'y'
                if (instance.EntityType.Name.EndsWith("y"))
                {
                    instance.GeneratedBy.Sequence("Module.Module_Mod_" + instance.EntityType.Name.Substring(0, instance.EntityType.Name.Length - 1) + "ies");
                }
                else
                {
                    instance.GeneratedBy.Sequence("Module.Module_Mod_" + instance.EntityType.Name + "s");
                }
            }
            else if (cats.Contains(instance.EntityType.Name))
            {
                //instance.GeneratedBy.Sequence("Module.Module_Cat_" + instance.EntityType.Name + "s");
                if (instance.EntityType.Name.EndsWith("y"))
                {
                    instance.GeneratedBy.Sequence("Module.Module_Cat_" + instance.EntityType.Name.Substring(0, instance.EntityType.Name.Length - 1) + "ies");
                }
                else if (instance.EntityType.Name.EndsWith("us"))
                {
                    instance.GeneratedBy.Sequence("Module.Module_Cat_" + instance.EntityType.Name + "es");
                }
                else
                {
                    instance.GeneratedBy.Sequence("Module.Module_Cat_" + instance.EntityType.Name + "s");
                }
            }
            ////////else if (occ_cats.Contains(instance.EntityType.Name))
            ////////{
            ////////    //occ.Cat_OrganizationLevels_OrganizationLevelID_SEQ (schema + prefix + table name + entity name + 'ID_SEQ')
            ////////    if (instance.EntityType.Name.EndsWith("y"))
            ////////    {
            ////////        instance.GeneratedBy.Sequence("occ.Cat_" + instance.EntityType.Name.Substring(0, instance.EntityType.Name.Length - 1) + "ies_" + instance.EntityType.Name + "ID_SEQ");
            ////////    }
            ////////    else
            ////////    {
            ////////        instance.GeneratedBy.Sequence("occ.Cat_" + instance.EntityType.Name + "s_" + instance.EntityType.Name + "ID_SEQ");
            ////////    }
            ////////}
            ////////else if (occ_lts.Contains(instance.EntityType.Name))
            ////////{
            ////////    // occ.LT_Occupations_OccupationID_SEQ (schema + prefix + table name + entity name + 'ID_SEQ')
            ////////    if (instance.EntityType.Name.EndsWith("y"))
            ////////    {
            ////////        instance.GeneratedBy.Sequence("occ.LT_" + instance.EntityType.Name.Substring(0, instance.EntityType.Name.Length - 1) + "ies_" + instance.EntityType.Name + "ID_SEQ");
            ////////    }
            ////////    else
            ////////    {
            ////////        instance.GeneratedBy.Sequence("occ.LT_" + instance.EntityType.Name + "s_" + instance.EntityType.Name + "ID_SEQ");
            ////////    }
            ////////}
            else if (lookups.Contains(instance.EntityType.Name))
            {
                //instance.GeneratedBy.Sequence("Module.Module_LT_" + instance.EntityType.Name + "s");
                if (instance.EntityType.Name.EndsWith("y"))
                {
                    instance.GeneratedBy.Sequence("Module.Module_LT_" + instance.EntityType.Name.Substring(0, instance.EntityType.Name.Length - 1) + "ies");
                }
                else
                {
                    instance.GeneratedBy.Sequence("Module.Module_LT_" + instance.EntityType.Name + "s");
                }
            }
            else if (mqe.Contains(instance.EntityType.Name))
            {
                if (instance.EntityType.Name.EndsWith("y"))
                {
                    instance.GeneratedBy.Sequence("Module." + instance.EntityType.Name.Replace("MQE", "MQE_").Substring(0, instance.EntityType.Name.Length) + "ies");
                }
                else
                {
                    instance.GeneratedBy.Sequence("Module." + instance.EntityType.Name.Replace("MQE", "MQE_") + "s");
                }
            }
            else if (cr.Contains(instance.EntityType.Name))
            {
                instance.GeneratedBy.Sequence("OCC.SeqCR_" + instance.EntityType.Name + "ID");
            }
            else
            {
                instance.GeneratedBy.Identity();
            }

            instance.UnsavedValue("0");

		}

	}

    public class SQLPrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {

            instance.GeneratedBy.Identity();
            instance.UnsavedValue("0");
        }

    }
}
