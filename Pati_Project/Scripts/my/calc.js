/* =============================================================================
 # UK National Insurance 2013 calculator utility function
 # 
 # If you’re employed
 # You pay Class 1 National Insurance contributions. The rates are:
 # 
 # 12% on your yearly earnings between £7748 and £41444
 # 2% on any yearly earnings over £7748
 # 
 # 12% on your weekly earnings between £149 and £797
 # 2% on any weekly earnings over £797
 # 
 # https://www.gov.uk/national-insurance/how-much-national-insurance-you-pay
 #
 # Usage:
 #
 #    var NI = nationalInsurance('2500');             // earns 2,500 a month
 #    var NI = nationalInsurance('30000', 'yearly');  // earns 30,000 a year
 #    var NI = nationalInsurance('115.38', 'daily');  // earns 115.38 a day
 #    var NI = nationalInsurance('576.92', 'week');   // earns 576.92 a week
 #
 ============================================================================ */

var nationalInsurance = function (income, timespan) {
  // default timespan to monthly
  if (timespan == null) timespan = 'monthly';

  var lowerBand, upperBand;

  switch (timespan) {

    case 'monthly':
      lowerBand = 672; // 645.666666667
      upperBand = 3583; // 3453.666666667
      break;
  
    default:
      throw new Error("Invalid timespan '" + timespan + "'! Valid timespans (" +
        "'yearly', 'monthly', 'weekly', 'daily')");
  }

  // return calculated value
  return calculate();

  function calculate () {
    if (income < lowerBand) {
      // congratulations, you don't have to pay any NI contributions
      return 0;
    }
    else {
      if (income <= upperBand) {
        // 12% on your weekly earnings between £149 and £797
        return (income - lowerBand) * 0.12;
      }
      else {
        // MAX - 12% on your weekly earnings between £149 and £797
        var maxTwelvePercent = (upperBand - lowerBand) * 0.138;

        // 2% on any weekly earnings over £797
        var twoPercent = (income - upperBand) * 0.0585;

        return maxTwelvePercent + twoPercent;
      }
    }
  }
}