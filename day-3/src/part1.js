const { promises: fsp } = require("fs");

async function RunPart1(lines) {
  const processed = processInput(lines);

  const result = getGamma(processed) * getEpsilon(processed);
  console.log("Part 1: ", { result });
}

function processInput(lines) {
  const bitLength = lines[0].length;

  const counter = new Array(bitLength).fill(0);
  lines.forEach((line) => {
    [...line].forEach((char, index) => {
      const num = char === "0" ? -1 : 1;
      const currentCount = counter[index];
      counter[index] = currentCount + num;
    });
  });

  return counter.map((n) => Math.max(Math.sign(n), 0));
}

function getGamma(bitArray) {
  return parseInt(bitArray.join(""), 2);
}

function getEpsilon(bitArray) {
  const flippedBits = flipBitArray(bitArray);
  return parseInt(flippedBits.join(""), 2);
}

function flipBitArray(bitArray) {
  return bitArray.map((b) => 1 - b);
}

module.exports = {
  RunPart1,
  processInput,
  flipBitArray,
  getGamma,
  getEpsilon,
};
