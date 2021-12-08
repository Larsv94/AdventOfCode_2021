async function RunPart2(lines) {
  const oxygen = getRatingForValuation(lines, { minus: 0, equal: 1, plus: 1 });
  const CO2 = getRatingForValuation(lines, { minus: 1, equal: 0, plus: 0 });
  const result = toDec(oxygen) * toDec(CO2);
  console.log("Part 2:", { result });
}

function getRatingForValuation(lines, { minus, equal, plus }) {
  const valuation = {
    0: equal,
    "-1": minus,
    1: plus,
  };
  let pos = 0;
  let ratingLines = [...lines];
  while (ratingLines.length > 1) {
    const dominant = valuation[getDominantAtPosition(ratingLines, pos)];

    ratingLines = ratingLines.filter(
      (line) => line[pos] === dominant.toString()
    );
    pos++;
  }
  return ratingLines[0];
}

function getDominantAtPosition(lines, pos) {
  let counter = 0;
  lines.forEach((line) => {
    const num = line[pos] === "0" ? -1 : 1;
    counter = counter + num;
  });
  return Math.sign(counter);
}

function toDec(str) {
  return parseInt(str, 2);
}

module.exports = { RunPart2, getRatingForValuation, getDominantAtPosition };

//oxygen starts with 1, 0 = 1
//c02 starts with 0, 0 = 0
