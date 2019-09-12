const MINUTE          = 60;
const HOUR            = MINUTE*60;
const DAY             = HOUR*24;
const WEEK            = DAY*7;
const MONTH           = DAY*30;
const YEAR            = MONTH*12;
const IN_MILLISECONDS = 1000;

function SecsToTimeString(timeInSecs, shortText = false, hoursOnly = false)
{
    const secs    = parseInt(timeInSecs % MINUTE);
    const minutes = parseInt(timeInSecs % HOUR / MINUTE);
    const hours   = parseInt(timeInSecs % DAY  / HOUR);
    const days    = parseInt(timeInSecs / DAY);

    let ss = "";
    if (days)
        ss = ss + days + (shortText ? "d" : " Day(s) ");
    if (hours || hoursOnly)
        ss = ss + hours + (shortText ? "h" : " Hour(s) ");
    if (!hoursOnly)
    {
        if (minutes)
            ss = ss + minutes + (shortText ? "m" : " Minute(s) ");
        if (secs || (!days && !hours && !minutes) )
            ss = ss + secs + (shortText ? "s" : " Second(s).");
    }

    return ss;
}

export { SecsToTimeString };