using System;
using System.Collections.Generic;

namespace APBD_s31722_12.Models;

public partial class PrescriptionMedicament
{
    public int IdMedicament { get; set; }

    public int IdPrescription { get; set; }

    public int? Dose { get; set; }

    public string Details { get; set; } = null!;

    public virtual Medicament IdMedicamentNavigation { get; set; } = null!;

    public virtual Prescription IdPrescriptionNavigation { get; set; } = null!;
}
