using System;
using System.Collections.Generic;

public class Mzcr
{
    public DateTime modified { get; set; }
    public string source { get; set; }
    public List<Data> data { get; set; }
}

public class Data
{
    public string datum { get; set; }
    public int pocet_PCR_testy { get; set; }
    public int pocet_AG_testy { get; set; }
    public int typologie_test_indik_diagnosticka { get; set; }
    public int typologie_test_indik_epidemiologicka { get; set; }
    public int typologie_test_indik_preventivni { get; set; }
    public int typologie_test_indik_ostatni { get; set; }
    public int incidence_pozitivni { get; set; }
    public int pozit_typologie_test_indik_diagnosticka { get; set; }
    public int pozit_typologie_test_indik_epidemiologicka { get; set; }
    public int pozit_typologie_test_indik_preventivni { get; set; }
    public int pozit_typologie_test_indik_ostatni { get; set; }
    public int PCR_pozit_sympt { get; set; }
    public int PCR_pozit_asymp { get; set; }
    public int AG_pozit_symp { get; set; }
    public int AG_pozit_asymp_PCR_conf { get; set; }
}