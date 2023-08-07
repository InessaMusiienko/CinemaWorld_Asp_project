function solve(name, population, treasure){
    let city = {
        name,
        population, 
        treasure,
        taxRate: 10,
        collectTaxes() {
            this.treasure += this.population * this.taxRate;
        },
        applyGrowth(percentage) {
            this.population += Math.floor(this.population * percentage / 100);
        },
        applyRecession(percentage) {
            this.treasure -= Math.floor(this.treasure * percentage / 100);
        }
    }
    return city;
}

let city1 = solve('Tortuga', 7000, 15000);
console.log(city1);
city1.collectTaxes();
console.log(city1);