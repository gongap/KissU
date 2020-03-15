const inquirer = require('inquirer');
const execSync = require('child_process').execSync;

function install(options) {
    const paths = `src/app/routes/${options.name}`;
    tryClean(options.name);

    execSync(`git submodule add --name ${options.name} ${options.repo} ${paths}`);
    execSync(`git submodule init`);
    execSync(`git submodule update`);
}

function tryClean(name) {
    try {
        execSync(`git rm --cached ${name}`);
    } catch {}
}

inquirer.prompt([
    {
        type: 'input',
        name: 'name',
        message: 'What name would you like to use for the new service?',
        validate: (input) => {
            if (/[a-z]+/g.test(input))
                return true;
            return 'Please provide a valid service name ([a-z]+).';
        }
    },
    {
        type: 'input',
        name: 'repo',
        message: 'New service repository address?',
        validate: (input) => {
            if (/^(git@|https?:\/\/)/g.test(input))
                return true;
            return 'Please provide a valid repository address.';
        }
    },
]).then(res => install(res));
