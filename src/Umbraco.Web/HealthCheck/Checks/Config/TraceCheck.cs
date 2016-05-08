﻿using System.Collections.Generic;

namespace Umbraco.Web.HealthCheck.Checks.Config
{
    [HealthCheck("9BED6EF4-A7F3-457A-8935-B64E9AA8BAB3", "Trace Mode",
        Description = "Leaving trace mode enabled can make valuable information about your system available to hackers.",
        Group = "Live Environment")]
    public class TraceCheck : AbstractConfigCheck
    {
        public TraceCheck(HealthCheckContext healthCheckContext) : base(healthCheckContext) { }

        public override string FilePath
        {
            get { return "~/Web.config"; }
        }

        public override string XPath
        {
            get { return "/configuration/system.web/trace/@enabled"; }
        }

        public override ValueComparisonType ValueComparisonType
        {
            get { return ValueComparisonType.ShouldEqual; }
        }

        public override IEnumerable<AcceptableConfiguration> Values
        {
            get
            {
                return new List<AcceptableConfiguration>
                {
                    new AcceptableConfiguration { IsRecommended = true, Value = bool.FalseString.ToLower() }
                };
            }
        }

        public override string CheckSuccessMessage
        {
            get { return "Trace mode is disabled."; }
        }

        public override string CheckErrorMessage
        {
            get { return "Trace mode is currently enabled. It is recommended to disable this setting before go live."; }
        }

        public override string RectifySuccessMessage
        {
            get { return "Trace mode successfully disabled."; }
        }
    }
}