using MGSC;

namespace CrynanoLib.Extensions
{
    /// <summary>
    /// A set of extension methods for configuring PerkRecord instances.
    /// </summary>
    public static class PerkRecordExtensions
    {
        public static PerkRecord SetActiveImplant(this PerkRecord perk)
        {
            perk.PerkType = PerkType.ActiveImplant;
            return perk;
        }
        
        public static PerkRecord SetPassiveImplant(this PerkRecord perk)
        {
            perk.PerkType = PerkType.Passive;
            return perk;
        }
        
        public static PerkRecord SetCustomImplantType(this PerkRecord perk, PerkType perkType)
        {
            perk.PerkType = perkType;
            return perk;
        }
        
        public static PerkRecord SetCooldown(this PerkRecord perk, int cooldown)
        {
            perk.Parameters.Add(
                new PerkParameter
                {
                    Name = "ICooldown",
                    ValType = PerkParameter.ValueType.Int,
                    IntVal = cooldown,
                    FloatVal = 0,
                    BoolVal = false,
                    StrVal = ""
                });

            return perk;
        }
        
        public static PerkRecord SetDuration(this PerkRecord perk, int duration)
        {
            perk.Parameters.Add(
                new PerkParameter
                {
                    Name = "IDuration",
                    ValType = PerkParameter.ValueType.Int,
                    IntVal = duration,
                    FloatVal = 0,
                    BoolVal = false,
                    StrVal = ""
                });

            return perk;
        }

        public static PerkParameter AddCustomParameter(this PerkRecord perk, string parameterName)
        {
            var parameter = new PerkParameter
            {
                Name = parameterName,
                ValType = PerkParameter.ValueType.Int,
                IntVal = 0,
                FloatVal = 0,
                BoolVal = false,
                StrVal = ""
            };
            perk.Parameters.Add(parameter);
            return parameter;
        }
        
        public static void WithIntValue(this PerkParameter parameter, int intValue)
        {
            parameter.ValType = PerkParameter.ValueType.Int;
            parameter.IntVal = intValue;
        }
        
        public static void WithFloatValue(this PerkParameter parameter, float floatValue)
        {
            parameter.ValType = PerkParameter.ValueType.Float;
            parameter.FloatVal = floatValue;
        }
        
        public static void WithStrValue(this PerkParameter parameter, string strValue)
        {
            parameter.ValType = PerkParameter.ValueType.String;
            parameter.StrVal = strValue;
        }
        
        public static void WithBoolValue(this PerkParameter parameter, bool boolValue)
        {
            parameter.ValType = PerkParameter.ValueType.Boolean;
            parameter.BoolVal = boolValue;  
        }
    }
}