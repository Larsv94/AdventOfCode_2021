const { processInput, flipBitArray, getGamma } = require("./part1");

const testLines = [
  "00100",
  "11110",
  "10110",
  "10111",
  "10101",
  "01111",
  "00111",
  "11100",
  "10000",
  "11001",
  "00010",
  "01010",
];

test("should return correct dominant number", () => {
  const result = processInput(testLines);
  expect(result).toEqual([1, 0, 1, 1, 0]);
});

test("should flip bit array", () => {
  const result = flipBitArray([1, 0, 1, 1, 0]);
  expect(result).toEqual([0, 1, 0, 0, 1]);
});

test("should convert bit array to decimal", () => {
  const result = getGamma([1, 0, 1, 1, 0]);
  expect(result).toBe(22);
});

