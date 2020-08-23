using System;
using System.Runtime.Serialization;
using Stardraw;
using Stardraw.Control;
using Stardraw.Project;
using Stardraw.Serial;

public class Lexicon : SerialInPortInstance {

    /// <summary>
    ///     Initializes a new instance of the class.
    /// </summary>
    public Lexicon(ProductInstance productInstance, Port port): base(productInstance, port) {
    }

    /// <summary>
    ///     Initiates a DAB scan.
    /// </summary>
    [Controllable]
    public void ScanDAB() {
        // St   = 0x21
        // Zn   = 0x01
        // Cc   = 0x24
        // Dl   = 0x01
        // Data = 0xF0 = Start DAB scan
        // Et   = 0x0D
        Write(new byte[] { 0x21, 0x01, 0x24, 0x01, 0xF0, 0x0D });
    }

    [Controllable]
    public void ScanDown() {
        // St   = 0x21
        // Zn   = 0x01
        // Cc   = 0x23
        // Dl   = 0x01
        // Data = 0x01 = Scan up
        //        0x02 = Scan down
        // Et   = 0x0D
        Write(new byte[] { 0x21, 0x01, 0x23, 0x01, 0x02, 0x0D });
    }

    [Controllable]
    public void ScanUp() {
        // St   = 0x21
        // Zn   = 0x01
        // Cc   = 0x23
        // Dl   = 0x01
        // Data = 0x01 = Scan up
        //        0x02 = Scan down
        // Et   = 0x0D
        Write(new byte[] { 0x21, 0x01, 0x23, 0x01, 0x01, 0x0D });
    }
}