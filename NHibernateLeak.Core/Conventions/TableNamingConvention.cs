using System.Collections.Generic;
using FluentNHibernate.Conventions;

namespace NHibernateLeak.Core.Conventions
{
    public class TableNamingConvention : IClassConvention
    {
		public void Apply(FluentNHibernate.Conventions.Instances.IClassInstance instance)
		{
            //throw new NotImplementedException();
            // set options for Mod_, LT_, and Cat_ table names using list objects
            List<string> mods = new List<string>();
            mods.AddRange(new string[] {"CallTime","Case","ContactImport", "ContactOrganization",
                                        "Contribution","ContributionDetail",
                                        "PhoneBankCall","PhoneBankSession","PreferredWorkType",
                                        "PreferredWorkSchedule","Shift","ContactSkill","SocialNetwork",
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

            // This list maps to module.cat_* tables under module schema
            List<string> cats = new List<string>();
            cats.AddRange(new string[] {"Activity","Event",
                                        "FileLayoutColumnPair","FileLayout","Flag","FlagGroup","Location",
                                        "ModuleOrganization", "OrgNamedPrecincts", "PaymentSource","PhoneBank","ResponseCode",
                                        "ResponseSetMember","ResponseSet","Skill","Solicitor","VoterPhoneBankScript",
                                        "WorkType","VolunteerOrganization","VolunteerOrganizer",
                                        "Script", "CanvassTarget","CanvassTask", 
                                        "VoterPhoneBank","VoterPhoneBankLink","VoterPhoneBankCall","VoterPhoneBankTarget",
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
                                        "VolunteerLevel",
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
                                        "OrganizationView","OrganizationViewDetail",
                                        "OrganizationDataShare",
                                        "DataShareFlag"
            });

            // This list maps to occ.cat_* tables under occ schema
            List<string> occ_cats = new List<string>();
            occ_cats.AddRange(new string[] {

            });

            // This list maps to occ.LT_* tables under occ schema
            List<string> occ_lts = new List<string>();
            occ_lts.AddRange(new string[] {
                "MeetingFrequency"
            });

            List<string> lookups = new List<string>();
            lookups.AddRange(new string[] {"CallOutcome","CallTimeOption","CampaignFunction","ContributionType","DonationMaximum",
                                        "EntityType","FileType","FlagSource","OrganizationTitle","PaymentCategory","PaymentSourceType",
                                        "PaymentType","ProfileType","Report","ShiftRecurrenceOption","ShiftUpdateOption","SocialNetworkType",
                                        "TimeSlot","TimeToCall","VoterPhoneBankFilter","WorkScheduleOption",
                                        "WorkTypeDefault","PledgeRecurrenceOption",
                                        "ScriptType"});

            List<string> qb = new List<string>();
            qb.AddRange(new string[] {"TableJoin", "Table", "QueryDetail", "QueryCriterion", "QueryCategory", "Query",
										"JoinDetail", "GroupCondition", "Field", "CriteriaGroup", "CriteriaConditionQuery",
										"CriteriaConditionBase", "CriteriaCondition", "ControlDetailGroup", "ControlDetailCondition",
										"ControlDetail", "Control", "Condition", "FreehandControlDetail"});

            List<string> cr = new List<string>();
            cr.AddRange(new string[] {"Category", "DefaultField", "DefaultFieldOption", "DefaultFieldSetUser", "DisplayOption", "Element",
										"Group", "GroupType", "Layout", "SelectedStaticColumn" });

            List<string> mqe = new List<string>();
            mqe.AddRange(new string[] {"MQEControlType", "MQEControl", "MQEDataType", "MQEDatabaseType", "MQEQuery", 
                                    "MQEQueryCategory", "MQEQueryDefinition", "MQEQueryGroupMember", "MQEQueryGroup", "MQEQueryOperator", 
                                    "MQEQuerySelectByType", "MQEQueryTableJoin", "MQEQueryTable" });

            // test lists for entity
            string tableName;
            if (mods.Contains(instance.EntityType.Name))
            {
                tableName = "Module.Mod_" + instance.EntityType.Name + "s";
            }
            else if (cats.Contains(instance.EntityType.Name))
            {
                if (instance.EntityType.Name.EndsWith("us"))
                {
                    tableName = "Module.Cat_" + instance.EntityType.Name + "es";
                }
                else
                {
                    tableName = "Module.Cat_" + instance.EntityType.Name + "s";
                }
            }
            else if (occ_cats.Contains(instance.EntityType.Name))
            {
                //if (instance.EntityType.Name.EndsWith("y")) - handled below

                tableName = "Cat_" + instance.EntityType.Name + "s";
            }
            else if (occ_lts.Contains(instance.EntityType.Name))
            {
                if (instance.EntityType.Name.EndsWith("y"))
                {
                    tableName = "Cat_" + instance.EntityType.Name.Substring(0, instance.EntityType.Name.Length - 2) + "ies";
                }
                else
                {
                    tableName = "LT_" + instance.EntityType.Name + "s";
                }
            }
            else if (lookups.Contains(instance.EntityType.Name))
            {
                tableName = "Module.LT_" + instance.EntityType.Name + "s";
            }
            else if (mqe.Contains(instance.EntityType.Name))
            {
                tableName = "Module." + instance.EntityType.Name + "s";
            }
            else if (qb.Contains(instance.EntityType.Name))
            {
                tableName = "QueryBuilder.QB" + instance.EntityType.Name + "s";

                if (instance.EntityType.Name == "QueryCriterion")
                {
                    tableName = "QueryBuilder.QBQueryCriteria";

                }
            }
            else if (cr.Contains(instance.EntityType.Name))
            {
                tableName = "CR_" + instance.EntityType.Name;
            }
            else
            {
                tableName = "Module." + instance.EntityType.Name + "s";
            }

            // check for plural 'y'
            if (instance.EntityType.Name.EndsWith("y") && !tableName.StartsWith("CR_"))
            {
                tableName = tableName.Substring(0, tableName.Length - 2) + "ies";
            }

            instance.Table(tableName);
			
		}
	}
}
