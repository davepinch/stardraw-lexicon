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

/*
public static class Packet {

    /// <summary>
    ///     Decrements the frequency in 0x05MHz steps.
    /// </summary>
    static byte[] DecrementTunerFrequency(byte zone) {
        // St   = 0x21
        // Zn   = Zone number
        // Cc   = 0x16
        // Dl   = 0x01
        // Data = 0x00 = Decrement tuner frequency by 1 step
        //        0x01 = Increment tuner frequency by 1 step
        //        0xF0 = Request the current tuner frequency
        // Et   = 0x0D
        return new byte[] { 0x21, zone, 0x16, 0x01, 0x00, 0x0D };
    }


    /// <summary>
    ///     Increments the frequency in 0x05MHz steps.
    /// </summary>
    static byte[] IncrementTunerFrequency(byte zone) {
        // St   = 0x21
        // Zn   = Zone number
        // Cc   = 0x16
        // Dl   = 0x01
        // Data = 0x00 = Decrement tuner frequency by 1 step
        //        0x01 = Increment tuner frequency by 1 step
        //        0xF0 = Request the current tuner frequency
        // Et   = 0x0D
        return new byte[] { 0x21, zone, 0x16, 0x01, 0x01, 0x0D };
    }

    /// <summary>
    ///     Request the direct mode status on zone 1 (the specification
    ///     does not indicate other zones may be specified).
    /// </summary>
    static byte[] RequestDirectModeStatus() {

        // St   = 0x21
        // Zn   = 0x01
        // Cc   = 0x0F
        // Dl   = 0x01
        // Data = 0xF0 - Request mode setting
        // Et   = 0x0D
        return new byte[] { 0x21, 0x01, 0x0F, 0x01, 0xF0, 0x0D };
    }

    /// <summary>
    ///     Requests information on the current station programme
    ///     type from the FM source in the given zone. If FM is not
    ///     selected on the given zone, then an error 0x85 will be returned.
    /// </summary>
    static byte[] RequestGenre(byte zone) {
        // St   = 0x21
        // Zn   = Zone number
        // Cc   = 0x03
        // Dl   = 0x01
        // Data = 0xF0 - FM program type
        // Et   = 0x0D
        return new byte[] { 0x21, zone, 0x03, 0x01, 0xF0, 0x0D };
    }

    /// <summary>
    ///     Requests the mute status of the audio in a zone.
    /// </summary>
    static byte[] RequestMuteStatus(byte zone) {
        // St   = 0x21
        // Zn   = Zone number
        // Cc   = 0x0E
        // Dl   = 0x01
        // Data = 0xF0 - Request mute status
        // Et   = 0x0D
        return new byte[] { 0x21, zone, 0x0E, 0x01, 0xF0, 0x0D };
    }

    /// <summary>
    ///     Requests network playback status.
    /// </summary>
    static byte[] RequestNetworkPlaybackStatus(byte zone) {
        // St   = 0x21
        // Zn   = Zone number
        // Cc   = 0x1C
        // Dl   = 0x01
        // Data = 0xF0 - Request network plaback status
        // Et   = 0x0D
        return new byte[] { 0x21, zone, 0x1C, 0x01, 0xF0, 0x0D };
    }

    /// <summary>
    ///     Requests the stand-by state of a zone.
    /// </summary>
    static byte[] RequestPower(byte zone) {
        // St   = 0x21
        // Zn   = Zone number
        // Cc   = 0x00
        // Dl   = 0x01
        // Data = 0xF0 - Request power state
        // Et   = 0x0D
        return new byte[] { 0x21, zone, 0x00, 0x01, 0xF0, 0x0D };
    }

    /// <summary>
    ///     Requests the source currently selected for a given zone.
    /// </summary>
    static byte[] RequestSource(byte zone) {
        // St   = 0x21
        // Zn   = Zone number
        // Cc   = 0x1D
        // Dl   = 0x01
        // Data = 0xF0
        // Et   = 0x0D
        return new byte[] { 0x21, zone, 0x1D, 0x01, 0xF0, 0x0D };
    }

    /// <summary>
    ///     Requests the current tuner frequency.
    /// </summary>
    static byte[] RequestTuner(byte zone) {
        // St   = 0x21
        // Zn   = Zone number
        // Cc   = 0x16
        // Dl   = 0x01
        // Data = 0x00 = Decrement tuner frequency by 1 step
        //        0x01 = Increment tuner frequency by 1 step
        //        0xF0 = Request the current tuner frequency
        // Et   = 0x0D
        return new byte[] { 0x21, zone, 0x16, 0x01, 0xF0, 0x0D };
    }

    /// <summary>
    ///     Sets the zone 1 OSD.
    /// </summary>
    static byte[] SetZone1OSD(bool state) {
        // St   = 0x21
        // Zn   = 0x01
        // Cc   = 0x4E
        // Dl   = 0x01
        // Data = 0xF0 = Request current zone 1 OSD on/off state
        //        0xF1 = Set zone 1 OSD to on
        //        0xF2 = Set zone 1 OSD to off
        // Et   = 0x0D
        byte param = state ? (byte)0xF1 : (byte)0xF2;
        return new byte[] { 0x21, zone, 0x4E, 0x01, param, 0x0D };
    }

}
*/

